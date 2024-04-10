namespace BinarySerializer.UbiArt
{
    /*
Game:                                 Version:    Unk1:    Unk2:    Unk3:    Unk4:    Unk5:    Unk6:     Unk9:    Unk7:    EngineVersion:

Rayman Origins (PC Demo):                    3        0        -        0        1        1        0         -   2727956186         0
Rayman Origins (PC):                         3        0        -        0        1        1        0         -   877930951          0
Rayman Origins (Wii):                        3        6        -        0        1        1        0         -   1698768603         0
Rayman Origins (PS Vita):                    3        7        -        0        1        1        0         -   559042371          0
Rayman Origins (PS3):                        3        3        -        0        1        1        0         -   1698768603         0
Rayman Origins (Xbox 360):                   3        1        -        0        1        1        0         -   1698768603         0
Rayman Origins (3DS):                        4        5        -        0        1        1        0         -   1635089726         0
Rayman Legends (PC):                         5        0        -        0        1        1        0         -   1274838019         0
Rayman Legends Challenges App (Wii U):       5        7        -        0        1        1    70107         -   2662508568        62127
Rayman Legends (Wii U Demo):                 5        7        -        0        1        1        0         -   1182590121        48117
Rayman Legends (Wii U):                      5        7        -        0        1        1    78992         -   2697850994        84435
Rayman Legends (Xbox 360):                   5        1        -        0        1        1    79408         -   410435206          0
Rayman Legends (PS3):                        5        2        -        0        1        1    79403         -   410435206         86846
Rayman Legends (PS Vita):                    5        6        -        0        1        1        0         -   2869177618         0
Just Dance 2017 (Wii U):                     5        8        -        0        0        0        0         -   3346979248        241478
Valiant Hearts (Android):                    7       10        -        0        1        1        0         0   3713665533         0
Child of Light (PC Demo):                    7        0        -        0        1        1        0         -   3669482532        30765
Child of Light (PS Vita):                    7        6        -        0        1        1        0         -   19689438           0
Rayman Legends (PS4):                        7        8        -        0        1        1    80253         -   2973796970        117321
Rayman Legends (Switch):                     7       10        -        0        1        1        0         -   2514498303         0
Gravity Falls (3DS):                         7       10        -        0        1        1        0         -   4160251604         0
Rayman Adventures 3.9.0 (Android):           8       12       11        1        1        1   127901         -   3037303110        277220
Rayman Adventures 3.9.0 (iOS):               8       12       10        1        1        1   127895         -   3037303110        277216
Rayman Mini 1.0 (Mac):                       8       12       12        1        1        1     3771         -   800679911         3771
Rayman Mini 1.1 (Mac):                       8       12       12        1        1        1     3826         -   2057063881        3826
Rayman Mini 1.2 (Mac):                       8       12       12        1        1        1     4533         -   2293139714        4533
*/

    public class BundleBootHeader : BinarySerializable
    {
        public uint Version { get; set; }
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint BaseOffset { get; set; }
        public uint FilesCount { get; set; }
        public bool Unknown3 { get; set; }
        public bool Unknown4 { get; set; }
        public bool Unknown5 { get; set; }
        public uint Unknown6 { get; set; }
        public uint Unknown7 { get; set; }
        public uint EngineVersion { get; set; }
        public uint BlockSize { get; set; } // 0 if not compressed
        public uint BlockCompressedSize { get; set; }
        public uint Unknown9 { get; set; }

        public bool IsBlockCompressed => BlockSize != 0;
        public bool SupportsCompressedBlock => Version >= 6;

        public static IStreamEncoder GetEncoder(uint bundleVersion, long decompressedSize)
        {
            // Use LZMA
            if (bundleVersion >= 8)
                return new SevenZipEncoder(decompressedSize);
            // Use ZLib
            else
                return new ZLibEncoder();
        }

        public override void SerializeImpl(SerializerObject s)
        {
            // Serialize and verify the magic header
            s.SerializeMagic(0x50EC12BA);

            // Serialize the version
            Version = s.Serialize<uint>(Version, name: nameof(Version));

            // Serialize first unknown value
            Unknown1 = s.Serialize<uint>(Unknown1, name: nameof(Unknown1));

            // Serialize second unknown value if version is above or equal to 8
            if (Version >= 8)
                Unknown2 = s.Serialize<uint>(Unknown2, name: nameof(Unknown2));

            // Serialize offset and file count
            BaseOffset = s.Serialize<uint>(BaseOffset, name: nameof(BaseOffset));
            FilesCount = s.Serialize<uint>(FilesCount, name: nameof(FilesCount));

            // Serialize unknown values
            Unknown3 = s.SerializeUbiArtBool(Unknown3, name: nameof(Unknown3));
            Unknown4 = s.SerializeUbiArtBool(Unknown4, name: nameof(Unknown4));
            Unknown5 = s.SerializeUbiArtBool(Unknown5, name: nameof(Unknown5));
            Unknown6 = s.Serialize<uint>(Unknown6, name: nameof(Unknown6));

            if (s.GetRequiredSettings<UbiArtSettings>().Game == Game.ValiantHearts)
                Unknown9 = s.Serialize<uint>(Unknown9, name: nameof(Unknown9));

            Unknown7 = s.Serialize<uint>(Unknown7, name: nameof(Unknown7));
            EngineVersion = s.Serialize<uint>(EngineVersion, name: nameof(EngineVersion));

            if (SupportsCompressedBlock)
            {
                BlockSize = s.Serialize<uint>(BlockSize, name: nameof(BlockSize));
                BlockCompressedSize = s.Serialize<uint>(BlockCompressedSize, name: nameof(BlockCompressedSize));
            }
        }
    }
}