using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.Json;
using CommandLine;
using Kohi.Kintsugi;
using Kohi.Kintsugi.ContractDefinition;
using Nethereum.JsonRpc.Client;
using Nethereum.JsonRpc.WebSocketClient;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace Kohi
{
    internal static class Program
    {
        private const string AccountPrivateKey = "0xb0a587bc9681a7333763f84c3b90a4d58bd01b5fb0635ac16187f6f55e792a57";
        private const string KintsugiContractAddress = "0xA9a6506b20b234B015B6f6183EFf26fcBAf8f349";

        static Program()
        {
            ClientBase.ConnectionTimeout = TimeSpan.FromHours(100);
            WebSocketClient.ForceCompleteReadTotalMilliseconds = (int) TimeSpan.FromHours(100).TotalMilliseconds;
        }

        private static async Task Main(string[] args)
        {
            await Masthead.PrintAsync();

            var parser = new Parser(o =>
            {
                o.EnableDashDash = true;
                o.HelpWriter = Console.Error;
            });

            // object is a dummy verb placeholder
            await parser.ParseArguments<RenderOptions, object>(args)
                .MapResult((RenderOptions options) => RenderCommandAsync(options), _ => Task.FromResult(1));
        }

        private static async Task<int> RenderCommandAsync(RenderOptions options)
        {
            var json = await File.ReadAllTextAsync("manifest.json");
            var lookup = JsonSerializer.Deserialize<Dictionary<int, int>>(json);
            if (lookup == null)
            {
                await Console.Error.WriteLineAsync("Manifest not found.");
                return -1;
            }

            if (!lookup.TryGetValue(options.TokenId, out var seed))
            {
                await Console.Error.WriteLineAsync("TokenID not found.");
                return -1;
            }
            
            var sw = Stopwatch.StartNew();
            var bitmap = new Bitmap(1024, 1024);

            using var client = new WebSocketClient("ws://localhost:8546");
            var account = new Account(AccountPrivateKey);
            var web3 = new Web3(account, client);

            var service = new KintsugiService(web3, KintsugiContractAddress);

            var attributes = await service.GetAttributesQueryAsync(seed);
            Console.WriteLine(attributes);
            
            for (var i = 0; i < 64; i++)
            {
                var result = RenderChunkAsync(service, (short)i, (int) options.TokenId, seed, options)
                    .ConfigureAwait(false).GetAwaiter().GetResult();

                await Console.Out.WriteLineAsync($"chunk length: {result?.Count}");

                if (result != null && result.Count != 0)
                {
                    var startX = i % 8 * 128;
                    var startY = i / 8 * 128;
                    for (var x = 0; x < 128; x++)
                    for (var y = 0; y < 128; y++)
                    {
                        var color = Color.FromArgb((int)result[128 * y + x]);

                        lock (bitmap)
                        {
                            bitmap.SetPixel(startX + x, startY + y, color);
                        }
                    }

                    lock (bitmap)
                    {
                        bitmap.Save($"{options.TokenId}.png", ImageFormat.Png);
                    }
                }
            }
            
            await Console.Out.WriteLineAsync($"--Finished full render, took {sw.Elapsed}");
            return 0;
        }

        private static async Task<List<uint>> RenderChunkAsync(
            KintsugiService kintsugi,
            short index, 
            int tokenId,
            int seed, 
            RenderOptions options)
        {
            try
            {
                await Console.Out.WriteLineAsync($"Started rendering chunk #{index + 1} on port 8456");
                var sw = Stopwatch.StartNew();

                var buffer = new List<uint>(16384);
                for (var i = 0; i < 16384; i++)
                    buffer.Add(0);

                var prng = new PRNG
                {
                    SeedArray = new List<int>(56)
                };

                for(var i =0; i < 56; i++)
                    prng.SeedArray.Add(0);
                
                var beginRenderFunc = new RenderFunction
                {
                    GasPrice = 0,
                    Args = new RenderArgs
                    {
                        Index = 0,
                        Buffer = buffer,
                        Prng = prng,
                        Seed = seed
                    }
                };

                var firstRender = await kintsugi.RenderQueryAsync(beginRenderFunc);
                buffer = firstRender.Results.Buffer;
                prng = firstRender.Results.Prng;

                for (byte stage = 1; stage < 104; stage++)
                {
                    var ssw = Stopwatch.StartNew();
                    
                    var func = new RenderFunction
                    {
                        GasPrice = 0,
                        Args = new RenderArgs
                        {
                            Index = index,
                            Stage = stage,
                            Seed = seed,
                            Buffer = buffer,
                            Prng = prng
                        }
                    };

                    await Console.Out.WriteLineAsync($"* START chunk #{index + 1} stage #{stage + 1}");

                    var result = await kintsugi.RenderQueryAsync(func);
                    if (result == null)
                    {
                        await Console.Error.WriteLineAsync($"ERR: null render response, took {sw.Elapsed}");
                        return buffer;
                    }

                    buffer = result.Results.Buffer;
                    prng = result.Results.Prng;

                    await Console.Out.WriteLineAsync($"* END chunk #{index + 1} stage #{stage + 1} took {ssw.Elapsed}");
                    
                    var bitmap = new Bitmap(128, 128);
                    for (var x = 0; x < 128; x++)
                    for (var y = 0; y < 128; y++)
                    {
                        var color = Color.FromArgb((int)buffer[128 * y + x]);
                        bitmap.SetPixel(x, y, color);
                    }

                    Directory.CreateDirectory("chunks");
                    var chunkPath = Path.Combine("chunks", $"{tokenId}-chunk-{index + 1}-stage-{stage + 1}.png");
                    bitmap.Save(chunkPath, ImageFormat.Png);
                }

                await Console.Out.WriteLineAsync($"--Finished rendering chunk #{index + 1} on port 8546, took {sw.Elapsed}");
                return buffer;
            }
            catch (Exception ex)
            {
                await Console.Error.WriteLineAsync($"ERR on rendering port 8546: {ex.Message} {ex.StackTrace}");
                return new uint[128 * 128].ToList(); // return transparent chunk
            }
        }
    }
}