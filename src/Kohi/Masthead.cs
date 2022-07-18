namespace Kohi
{
    internal static class Masthead
    {
        public static async Task PrintAsync()
        {
            var color = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            await Console.Out.WriteLineAsync(@"  _  __    _    _ 
 | |/ /___| |_ (_)
 | ' </ _ \ ' \| |
 |_|\_\___/_||_|_|
");

            Console.ForegroundColor = color;
        }
    }
}
