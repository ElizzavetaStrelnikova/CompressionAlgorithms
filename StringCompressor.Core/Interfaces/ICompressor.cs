namespace StringCompressor.Core.Interfaces
{
    public interface ICompressor
    {
        Task<string> Compress(string input);
        Task<string> Decompress(string compressed);
    }
}
