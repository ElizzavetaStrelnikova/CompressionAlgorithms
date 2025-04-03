using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCompressor.Core.Compressors;
using StringCompressor.Core.Interfaces;

namespace StringCompressor.Tests.CompressorTests
{
    [TestClass]
    public class RLECompressorTests
    {
        private ICompressor _compressor = new RLECompressor();

        [TestMethod]
        public void Compress_ShortString_ReturnsCompressed()
        {
            var (compressed, _) = _compressor.Compress("aaabbcccdde");

            Assert.IsFalse(string.IsNullOrEmpty(compressed));
            Assert.IsTrue(compressed.Length > 0);
        }

        [TestMethod]
        public void Decompress_ShortString_ReturnsOriginal()
        {
            string original = "aaabbcccdde";
            var (compressed, codes) = _compressor.Compress(original);
            string decompressed = _compressor.Decompress(compressed, codes);

            Assert.AreEqual(original, decompressed);
        }
    }
}
