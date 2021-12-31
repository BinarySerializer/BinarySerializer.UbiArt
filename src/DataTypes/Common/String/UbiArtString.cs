using System.Text;

namespace BinarySerializer.UbiArt
{
    public abstract class UbiArtString : BinarySerializable
    {
        protected abstract int CharSize { get; }

        public string Value { get; set; }

        /// <summary>
        /// Creates a new <see cref="string"/> from a <see cref="UbiArtString"/>
        /// </summary>
        /// <param name="path">The string value as a <see cref="UbiArtString"/></param>
        public static implicit operator string(UbiArtString path) =>
            path.Value;

        protected void SerializeString(SerializerObject s, Encoding encoding)
        {
            int length = 0;

            if (Value != null)
                length = encoding.GetByteCount(Value) / CharSize;

            // Serialize the length
            length = s.Serialize<int>(length, name: $"{nameof(Value)}.Length");

            // Serialize the string
            Value = s.SerializeString(Value, length * CharSize, encoding, name: nameof(Value));
        }
    }
}