namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// The localization data for a UbiArt game
    /// </summary>
    public class LocalizationData<LocString, UAString> : BinarySerializable
        where LocString : BinarySerializable, new()
        where UAString : UbiArtString, new()
    {
        /// <summary>
        /// The localized strings, categorized by the language index and the localization ID
        /// </summary>
        public LocStringValuePair<LocString>[] Strings { get; set; }

        /// <summary>
        /// The audio to use for each localized string
        /// </summary>
        public UbiArtKeyObjValuePair<int, LocalizationAudio<UAString>>[] Audio { get; set; }

        /// <summary>
        /// Unknown list of paths
        /// </summary>
        public UAString[] Paths { get; set; }

        /// <summary>
        /// Unknown values, used in Legends and later
        /// </summary>
        public uint[] Unknown { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Strings = s.SerializeUbiArtObjectArray<LocStringValuePair<LocString>>(Strings, name: nameof(Strings));
            Audio = s.SerializeUbiArtObjectArray<UbiArtKeyObjValuePair<int, LocalizationAudio<UAString>>>(Audio, name: nameof(Audio));
            Paths = s.SerializeUbiArtObjectArray<UAString>(Paths, name: nameof(Paths));

            Unknown = s.SerializeArray<uint>(Unknown, (s.CurrentLength - s.CurrentFileOffset) / sizeof(uint), name: nameof(Unknown));
        }
    }

    public class LocalizationData<UAString> : LocalizationData<UAString, UAString>
        where UAString : UbiArtString, new() { }
}