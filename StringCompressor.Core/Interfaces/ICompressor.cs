namespace StringCompressor.Core.Interfaces
{
    public interface ICompressor
    {
        public (string compressed, Dictionary<string, string> metadata) Compress(string input);

        public string Decompress(string compressed, Dictionary<string, string> metadata);

        public string AlgorithmName { get; }
    }
}
