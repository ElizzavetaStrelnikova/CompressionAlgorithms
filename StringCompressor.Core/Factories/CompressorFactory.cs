using StringCompressor.Core.Compressors;
using StringCompressor.Core.Interfaces;

namespace StringCompressor.Core.Factories
{
    public static class CompressorFactory
    {
        public static ICompressor Create(string algorithm)
        {
            return algorithm.ToLower() switch
            {
                "rle" => new RLECompressor(),
                "huffman" => new HuffmanCompressor(),
                _ => throw new ArgumentException("Unsupported algorithm")
            };
        }
    }
}
