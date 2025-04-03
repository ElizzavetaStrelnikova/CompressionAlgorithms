namespace StringCompressor.Core.Models
{
    public class HuffmanNode
    {
        public string Character { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
    }
}
