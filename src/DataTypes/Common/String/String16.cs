﻿using System.ComponentModel;
using System.Text;

namespace BinarySerializer.UbiArt
{
    [TypeConverter(typeof(String16Converter))]
    public class String16 : UbiArtString
    {
        protected override int CharSize => 2;

        /// <summary>
        /// Creates a new <see cref="String16"/> from a <see cref="string"/>
        /// </summary>
        /// <param name="value">The string value</param>
        public static implicit operator String16(string value) =>
            new String16() { Value = value };

        public override void SerializeImpl(SerializerObject s) => 
            SerializeString(s, s.CurrentBinaryFile.Endianness == Endian.Little ? Encoding.Unicode : Encoding.BigEndianUnicode);
    }
}