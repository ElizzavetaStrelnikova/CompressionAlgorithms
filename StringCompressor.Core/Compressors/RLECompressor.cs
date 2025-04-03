using StringCompressor.Core.Interfaces;
using System.Text;

namespace StringCompressor.Core.Compressors
{
    public class RLECompressor : ICompressor
    {
        public string AlgorithmName => "RLE";
        public (string compressed, Dictionary<string, string> metadata) Compress(string input)
        {
            var compressed = new StringBuilder();
            int count = 1;

            for (int i = 1; i <= input.Length; i++)
            {
                if (i < input.Length && input[i] == input[i - 1])
                {
                    count++;
                }
                else
                {
                    compressed.Append(input[i - 1]);
                    compressed.Append(count);
                    count = 1;
                }
            }

            return (compressed.ToString(), new Dictionary<string, string>());
        }

        public string Decompress(string compressed, Dictionary<string, string> metadata)
        {
            var output = new StringBuilder();
            int i = 0;

            while (i < compressed.Length)
            {
                char currentChar = compressed[i++];
                int numStart = i;

                while (i < compressed.Length && char.IsDigit(compressed[i])) i++;

                int count = int.Parse(compressed.Substring(numStart, i - numStart));
                output.Append(currentChar, count);
            }

            return output.ToString();
        }
    }
}
