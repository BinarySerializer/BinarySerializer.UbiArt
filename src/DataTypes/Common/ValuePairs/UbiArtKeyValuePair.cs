namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// A pair of two values, where the key and the value are values
    /// </summary>
    /// <typeparam name="TKey">The key value type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class UbiArtKeyValuePair<TKey, TValue> : BinarySerializable
    {
        /// <summary>
        /// The key
        /// </summary>
        public TKey Key { get; set; }

        /// <summary>
        /// The value
        /// </summary>
        public TValue Value { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Key = s.SerializeUbiArtGenericValue<TKey>(Key, name: nameof(Key));
            Value = s.SerializeUbiArtGenericValue<TValue>(Value, name: nameof(Value));
        }
    }
}