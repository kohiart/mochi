using CommandLine;

namespace Kohi
{
    [Verb("render", HelpText = "Render art from generated contracts.")]
    public sealed class RenderOptions
    {
        [Option('a', "artwork", HelpText = "The artwork to render.", Default = Artwork.Kintsugi)]
        public Artwork Artwork { get; set; }

        [Option('t', "tokenId", HelpText = "The token ID to render.", Required = true)]
        public int TokenId { get; set; }
    }
}
