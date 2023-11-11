using System.IO;
using SharpCompress.Compressors;
using SharpCompress.Compressors.Deflate;

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
            using var zStream = new ZlibStream(new NonDisposableWrapperStream(input), CompressionMode.Decompress);
            zStream.CopyTo(output);
        }

        public void EncodeStream(Stream input, Stream output)
        {
            using var zStream = new ZlibStream(new NonDisposableWrapperStream(input), CompressionMode.Compress);
            zStream.CopyTo(output);
        }
    }
}