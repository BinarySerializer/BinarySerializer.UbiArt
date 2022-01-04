namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// UbiArt localization audio data
    /// </summary>
    public class LocAudio<UAString> : BinarySerializable
        where UAString : UbiArtString, new()
    {
        /// <summary>
        /// Unknown value
        /// </summary>
        public uint Unknown0 { get; set; }

        /// <summary>
        /// The audio file
        /// </summary>
        public UAString AudioFile { get; set; }

        /// <summary>
        /// Unknown value
        /// </summary>
        public uint Unknown1 { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Unknown0 = s.Serialize<uint>(Unknown0, name: nameof(Unknown0));
            AudioFile = s.SerializeObject<UAString>(AudioFile, name: nameof(AudioFile));
            Unknown1 = s.Serialize<uint>(Unknown1, name: nameof(Unknown1));
        }
    }
}