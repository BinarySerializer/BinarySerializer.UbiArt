using System.Collections.Generic;
using System.Linq;

namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// A path for UbiArt games. The directory separator character is '/'.
    /// </summary>
    public class Path : BinarySerializable
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Path() { }

        /// <summary>
        /// Constructor for a full path
        /// </summary>
        /// <param name="fullPath">The full path</param>
        public Path(string fullPath)
        {
            int separatorIndex = fullPath.LastIndexOf('/') + 1;

            DirectoryPath = fullPath.Substring(0, separatorIndex);
            FileName = fullPath.Substring(separatorIndex);

            StringID = new StringID(fullPath);
            Flags = 2;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The full directory path, ending with the separator character
        /// </summary>
        public string DirectoryPath { get; set; }

        /// <summary>
        /// The file name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The String ID
        /// </summary>
        public StringID StringID { get; set; }

        /// <summary>
        /// The flags
        /// </summary>
        public uint Flags { get; set; }

        /// <summary>
        /// The full path including the directory path and file name
        /// </summary>
        public string FullPath => DirectoryPath + FileName;

        /// <summary>
        /// Gets the file extensions used for the file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetFileExtensions() => FileName.Split('.').Skip(1).Select(x => $".{x}");

        #endregion

        #region Public Methods

        /// <summary>
        /// Handles the serialization using the specified serializer
        /// </summary>
        /// <param name="s">The serializer</param>
        public override void SerializeImpl(SerializerObject s)
        {
            // Just Dance reads the values in reverse
            if (s.GetSettings<UbiArtSettings>().Game == Game.JustDance2017)
            {
                // Read the path
                FileName = s.SerializeObject<String8>(FileName, name: nameof(FileName));
                DirectoryPath = s.SerializeObject<String8>(DirectoryPath, name: nameof(DirectoryPath));
            }
            else
            {
                // Read the path
                DirectoryPath = s.SerializeObject<String8>(DirectoryPath, name: nameof(DirectoryPath));
                FileName = s.SerializeObject<String8>(FileName, name: nameof(FileName));
            }

            StringID = s.SerializeObject<StringID>(StringID, name: nameof(StringID));

            if (s.GetSettings<UbiArtSettings>().Game != Game.RaymanOrigins)
                Flags = s.Serialize<uint>(Flags, name: nameof(Flags));
        }

        #endregion
    }
}