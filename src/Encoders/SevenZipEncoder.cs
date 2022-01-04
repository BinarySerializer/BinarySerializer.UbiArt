using System.IO;
using SevenZip.Compression.LZMA;

namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// Encoder for 7-Zip compression
    /// </summary>
    public class SevenZipEncoder : IStreamEncoder
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="decompressedSize">The size of the decompressed data, if available</param>
        public SevenZipEncoder(long decompressedSize)
        {
            DecompressedSize = decompressedSize;
        }

        /// <summary>
        /// The size of the decompressed data, if available
        /// </summary>
        public long DecompressedSize { get; }

        public string Name => $"LZMA";

        public void DecodeStream(Stream input, Stream output)
        {
            SevenZipHelper.Decompress(input, output, DecompressedSize);
        }

        public void EncodeStream(Stream input, Stream output)
        {
            SevenZipHelper.Compress(input, output);
        }
    }
}