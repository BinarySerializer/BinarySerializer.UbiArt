namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// A pair of two values, where the key is a value and the value a serializable object
    /// </summary>
    /// <typeparam name="TKey">The key value type</typeparam>
    /// <typeparam name="TValue">The serializable object type</typeparam>
    public class UbiArtKeyObjValuePair<TKey, TValue> : BinarySerializable
        where TKey : struct
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
            Key = s.SerializeUbiArtGenericValue<TKey>(Key, name: nameof(Key));
            Value = s.SerializeObject<TValue>(Value, name: nameof(Value));
        }
    }
}