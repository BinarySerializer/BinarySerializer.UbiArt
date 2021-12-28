namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// A pair of two values, where the key is a serializable object and the value a value
    /// </summary>
    /// <typeparam name="TKey">The key serializable object type</typeparam>
    /// <typeparam name="TValue">The serializable object type</typeparam>
    public class UbiArtObjKeyValuePair<TKey, TValue> : BinarySerializable
        where TKey : BinarySerializable, new()
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
            Key = s.SerializeObject<TKey>(Key, name: nameof(Key));
            Value = s.SerializeUbiArtGenericValue<TValue>(Value, name: nameof(Value));
        }
    }
}