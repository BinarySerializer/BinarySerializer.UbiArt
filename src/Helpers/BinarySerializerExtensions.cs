using System;

namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// Extension methods for <see cref="SerializerObject"/>
    /// </summary>
    public static class BinarySerializerExtensions
    {
        /// <summary>
        /// Serializes an unknown generic value for UbiArt games
        /// </summary>
        /// <typeparam name="T">The type of value to serialize</typeparam>
        /// <param name="s">The serializer</param>
        /// <param name="value">The value</param>
        /// <param name="name">The object value name, for logging</param>
        /// <returns>The value</returns>
        public static T SerializeUbiArtGenericValue<T>(this SerializerObject s, T value, string name = null)
        {
            // Get the type
            Type t = typeof(T);

            // Check if the value is a boolean which we handle differently
            if (t == typeof(bool))
                return (T)(object)s.SerializeUbiArtBool((bool)(object)value, name: name);
            else
                return s.Serialize<T>(value, name: name);
        }

        public static T[] SerializeUbiArtObjectArray<T>(this SerializerObject s, T[] array, string name = null)
            where T : BinarySerializable, new()
        {
            // Serialize the size
            array = s.SerializeArraySize<T, uint>(array, name: name);

            // Serialize the array
            array = s.SerializeObjectArray<T>(array, array.Length, name: name);

            // Return the array
            return array;
        }

        public static T[] SerializeUbiArtArray<T>(this SerializerObject s, T[] array, string name = null)
        {
            // Serialize the size
            array = s.SerializeArraySize<T, uint>(array, name: name);

            // Serialize the array values
            for (int i = 0; i < array.Length; i++)
                array[i] = s.SerializeUbiArtGenericValue<T>(array[i], name: $"{nameof(array)}[{i}]");

            // Return the array
            return array;
        }

        public static bool SerializeUbiArtBool(this SerializerObject s, bool value, string name = null)
        {
            // Serialize the value and return as a bool
            return s.Serialize<uint>((uint)(value ? 1 : 0), name: name) != 0;
        }
    }
}