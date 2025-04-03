using StringCompressor.Core.Compressors;

namespace StringCompressor.Core
{
    public class Program
    {
        static void Main()
        {
            var userInput = Console.ReadLine();

            var compressor = new HuffmanCompressor();

            var (compressed, codes) = compressor.Compress(userInput);
            Console.WriteLine($"Compressed: {compressed}"); 

            string decompressed = compressor.Decompress(compressed, codes);
            Console.WriteLine($"Decompressed: {decompressed}");
            Console.WriteLine($"Success: {userInput == decompressed}");
        }
    }
}
