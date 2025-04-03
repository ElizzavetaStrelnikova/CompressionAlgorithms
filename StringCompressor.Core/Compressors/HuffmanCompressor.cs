using StringCompressor.Core.Interfaces;
using StringCompressor.Core.Models;
using System.Text;

namespace StringCompressor.Core.Compressors
{
    public class HuffmanCompressor : ICompressor
    {
        public string AlgorithmName => "Huffman";
        public  (string compressed, Dictionary<string, string> metadata) Compress(string input)
        {
            if (string.IsNullOrEmpty(input))
                return (string.Empty, new Dictionary<string, string>());

            var frequencies = input.GroupBy(c => c)
                              .ToDictionary(g => g.Key, g => g.Count());

            var priorityQueue = new List<HuffmanNode>();

            foreach (var entry in frequencies)
            {
                priorityQueue.Add(new HuffmanNode
                {
                    Character = entry.Key.ToString(),
                    Frequency = entry.Value
                });
            }

            while (priorityQueue.Count > 1)
            {
                priorityQueue = priorityQueue.OrderBy(n => n.Frequency).ToList();

                var left = priorityQueue[0];
                var right = priorityQueue[1];

                var parent = new HuffmanNode()
                {
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right
                };

                priorityQueue.RemoveRange(0, 2);
                priorityQueue.Add(parent);
            }

            var root = priorityQueue.FirstOrDefault();
            var metadata = new Dictionary<string, string>();
            GenerateCodes(root, "", metadata);

            var compressed = new StringBuilder();
            foreach (char c in input)
            {
                compressed.Append(metadata[c.ToString()]);
            }

            return (compressed.ToString(), metadata);

        }
        public  string Decompress(string compressed, Dictionary<string, string> metadata)
        {
            var reverseCodes = metadata.ToDictionary(entry => entry.Value, entry => entry.Key);

            var currentCode = new StringBuilder();
            var decompressed = new StringBuilder();

            foreach (char bit in compressed)
            {
                currentCode.Append(bit);
                if (reverseCodes.TryGetValue(currentCode.ToString(), out string character))
                {
                    decompressed.Append(character);
                    currentCode.Clear();
                }
            }

            return decompressed.ToString();
        }

        private static void GenerateCodes(HuffmanNode node, string code, Dictionary<string, string> metadata)
        {
            if (node == null)
                return;

            if (node.Left == null && node.Right == null)
            {
                metadata[node.Character] = code;
                return;
            }

            GenerateCodes(node.Left, code + "0", metadata);
            GenerateCodes(node.Right, code + "1", metadata);
        }
    }
}
