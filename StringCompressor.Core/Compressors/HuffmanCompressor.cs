using StringCompressor.Core.Interfaces;

namespace StringCompressor.Core.Compressors
{
    public class HuffmanCompressor : ICompressor
    {
        public Task<string> Compress(string input)
        {
            // Логика сжатия Хаффмана
        }

        public Task<string> Decompress(string compressed)
        {
            // Логика распаковки
        }
    }
}
