using System.IO;
using Ionic.Zlib;

namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// Encoder for ZLib
    /// </summary>
    public class ZLibEncoder : IStreamEncoder
    {
        public string Name => "ZLib";

        public void DecodeStream(Stream input, Stream output)
        {
            using var zStream = new ZlibStream(input, CompressionMode.Decompress, true);
            zStream.CopyTo(output);
        }

        public void EncodeStream(Stream input, Stream output)
        {
            using var zStream = new ZlibStream(input, CompressionMode.Compress, true);
            zStream.CopyTo(output);
        }
    }
}