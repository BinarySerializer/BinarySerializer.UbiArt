namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// A pair of two values, where the key and the value is a serializable object
    /// </summary>
    /// <typeparam name="TKey">The key serializable object type</typeparam>
    /// <typeparam name="TValue">The serializable object type</typeparam>
    public class UbiArtObjKeyObjValuePair<TKey, TValue> : BinarySerializable
        where TKey : BinarySerializable, new()
        where TValue : BinarySerializable, new()
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
            Value = s.SerializeObject<TValue>(Value, name: nameof(Value));
        }
    }
}