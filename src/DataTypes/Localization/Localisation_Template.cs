namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// The localization data for a UbiArt game. Either a .loc or .loc8 file.
    /// </summary>
    public class Localisation_Template<LocString, UAString> : BinarySerializable
        where LocString : BinarySerializable, new()
        where UAString : UbiArtString, new()
    {
        /// <summary>
        /// The localized strings, categorized by the language index and the localization ID
        /// </summary>
        public LocTextValuePair<LocString>[] Strings { get; set; }

        /// <summary>
        /// The audio to use for each localized string
        /// </summary>
        public UbiArtKeyObjValuePair<int, LocAudio<UAString>>[] Audio { get; set; }

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
            Strings = s.SerializeUbiArtObjectArray<LocTextValuePair<LocString>>(Strings, name: nameof(Strings));
            Audio = s.SerializeUbiArtObjectArray<UbiArtKeyObjValuePair<int, LocAudio<UAString>>>(Audio, name: nameof(Audio));
            Paths = s.SerializeUbiArtObjectArray<UAString>(Paths, name: nameof(Paths));

            // TODO: Don't use s.CurrentLength here as the file might be read directly from a bundle
            Unknown = s.SerializeArray<uint>(Unknown, (s.CurrentLength - s.CurrentFileOffset) / sizeof(uint), name: nameof(Unknown));
        }
    }

    public class Localisation_Template<UAString> : Localisation_Template<UAString, UAString>
        where UAString : UbiArtString, new() { }
}