namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// UbiArt localization audio data
    /// </summary>
    public class LocAudio<UAString> : BinarySerializable
        where UAString : UbiArtString, new()
    {
        /// <summary>
        /// The ID (always 0 in the file data)
        /// </summary>
        public uint LocalisationId { get; set; }

        /// <summary>
        /// The audio file
        /// </summary>
        public UAString AudioFile { get; set; }

        /// <summary>
        /// The audio volume
        /// </summary>
        public float AudioVolume { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            LocalisationId = s.Serialize<uint>(LocalisationId, name: nameof(LocalisationId));
            AudioFile = s.SerializeObject<UAString>(AudioFile, name: nameof(AudioFile));
            AudioVolume = s.Serialize<float>(AudioVolume, name: nameof(AudioVolume));
        }
    }
}