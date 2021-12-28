namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// The level progress data for Rayman Jungle Run
    /// </summary>
    public class JungleRun_SaveDataLevel : BinarySerializable
    {
        /// <summary>
        /// Indicates if the level is locked
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// The highest amount of Lums earned in the level. Max is 100.
        /// </summary>
        public ushort LumsRecord { get; set; }

        /// <summary>
        /// The level record time in milliseconds. This value is only used for the Livid Dead levels.
        /// </summary>
        public uint RecordTime { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            IsLocked = s.Serialize<bool>(IsLocked, name: nameof(IsLocked));
            LumsRecord = s.Serialize<ushort>(LumsRecord, name: nameof(LumsRecord));
            RecordTime = s.Serialize<uint>(RecordTime, name: nameof(RecordTime));
        }
    }
}