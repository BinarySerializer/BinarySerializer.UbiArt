namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// The save file data used for Rayman Jungle Run
    /// </summary>
    public class JungleRun_SaveData : BinarySerializable
    {
        public ushort Version { get; set; } // 1-3
        public JungleRun_SaveDataLevel[] LevelInfos { get; set; } // 70 levels for version 3
        public byte Unknown { get; set; } // Windows 10 version has 1 remaining byte - seems to be unused by the code?

        public override void SerializeImpl(SerializerObject s)
        {
            Version = s.Serialize<ushort>(Version, name: nameof(Version));
            LevelInfos = s.SerializeObjectArrayUntil<JungleRun_SaveDataLevel>(LevelInfos, x => s.CurrentFileOffset >= s.CurrentLength - 2, name: nameof(LevelInfos));
            Unknown = s.Serialize<byte>(Unknown, name: nameof(Unknown));
        }
    }
}