using System;
using System.ComponentModel;
using System.Globalization;

namespace BinarySerializer.UbiArt
{
    internal class String8Converter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string) || sourceType == typeof(String8))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string) || destinationType == typeof(String8))
                return true;
            else
                return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return value switch
            {
                string stringValue => new String8() { Value = stringValue },
                String8 ubiString => ubiString.Value,
                _ => base.ConvertFrom(context, culture, value)
            };
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (!(value is String8 ubiString))
                return base.ConvertTo(context, culture, value, destinationType);

            if (destinationType == typeof(string))
                return ubiString.Value;

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}