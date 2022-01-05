namespace BinarySerializer.UbiArt
{
    /*
        Textures:

        Origins (PC):                 (.dds)
        Origins (Wii):                Reverse endianness (.dds)
        Origins (3DS):                (.???)
        Origins (Vita):               (.gxt)
        Just Dance 2017 (Wii U)       (.png, .jpg, .gtx)

        Legends (PS3):                Missing DDS header (.dds)

        Legends demo (Wii U):         44 byte TEX header, version 8 (.gtx) (GFX2)
        Legends (Vita):               44 byte TEX header, version 9 (.gxt)

        Child of Light (PC):          52 byte TEX header, version 12 (.dds)
        Child of Light (Vita):        52 byte TEX header, version 12 (.gxt)
        Legends (PC):                 52 byte TEX header, version 13 (.dds)
        Legends (Wii U):              52 byte TEX header, version 13 (.gtx) (GFX2)

        Legends (PS4):                52 byte TEX header, version 23 (.gnf)
        Legends (Switch):             52 byte TEX header, version 23 (.xtx) (DFvN)
        Gravity Falls (3DS):          52 byte TEX header, version 23 (.???)

        Valiant Heart (Android):      56 byte TEX header, version 16 (.dds)
        Valiant Heart (Switch):       56 byte TEX header, version 16 (.xtx)
        Rayman Adventures (Android):  56 byte TEX header, version 17 (.dds)
        Rayman Adventures (iOS):      56 byte TEX header, version 17 (.dds, .pvr)
        Rayman Mini (Mac):            56 byte TEX header, version 17 (.dds)

    */

    /*
        IPK:

        Rayman Origins (PC, Wii, PS3, PS Vita):      3 
        Rayman Origins (3DS):                        4
        Rayman Legends (PC, Wii U, PS Vita, Switch): 5
        Just Dance 2017 (Wii U):                     5
        Valiant Hearts (Android):                    7
        Child of Light (PC, PS Vita):                7
        Rayman Legends (PS4):                        7
        Gravity Falls (3DS):                         7
        Rayman Adventures (Android, iOS):            8
        Rayman Mini (Mac):                           8

    */

    /// <summary>
    /// Settings for serializing UbiArt game formats
    /// </summary>
    public class UbiArtSettings
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="engineVersion">The engine version</param>
        /// <param name="platform">The platform</param>
        public UbiArtSettings(EngineVersion engineVersion, Platform platform)
        {
            EngineVersion = engineVersion;
            Platform = platform;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The engine version
        /// </summary>
        public EngineVersion EngineVersion { get; }

        /// <summary>
        /// The platform
        /// </summary>
        public Platform Platform { get; }

        public Endian GetEndian => EngineVersion == EngineVersion.RaymanOrigins && Platform == Platform.Nintendo3DS ? Endian.Little : Endian.Big;

        #endregion
    }
}