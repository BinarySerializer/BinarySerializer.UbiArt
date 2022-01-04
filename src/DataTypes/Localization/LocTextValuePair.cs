namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// Localization string value pair for UbiArt games
    /// </summary>
    public class LocTextValuePair<UAString> : BinarySerializable
        where UAString : BinarySerializable, new()
    {
        /// <summary>
        /// The localization key
        /// </summary>
        public int Key { get; set; }

        /// <summary>
        /// The localization value
        /// </summary>
        public UbiArtKeyObjValuePair<int, UAString>[] Value { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Key = s.Serialize<int>(Key, name: nameof(Key));
            Value = s.SerializeUbiArtObjectArray<UbiArtKeyObjValuePair<int, UAString>>(Value, name: nameof(Value));
        }
    }
}