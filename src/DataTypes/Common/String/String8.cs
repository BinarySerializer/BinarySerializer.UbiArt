using System.Text;

namespace BinarySerializer.UbiArt
{
    public class String8 : UbiArtString
    {
        /// <summary>
        /// Creates a new <see cref="String8"/> from a <see cref="string"/>
        /// </summary>
        /// <param name="value">The string value</param>
        public static implicit operator String8(string value) =>
            new String8() { Value = value };

        public override void SerializeImpl(SerializerObject s) => 
            SerializeString(s, Encoding.UTF8);
    }
}