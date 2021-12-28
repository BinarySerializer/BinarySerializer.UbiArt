using System;

namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// Attribute to use on <see cref="GameMode"/> fields, specifying the settings and data
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class GameModeInfoAttribute : Attribute
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="displayName">The game mode display name</param>
        /// <param name="engineVersion">The game engine version</param>
        /// <param name="platform">The platform</param>
        public GameModeInfoAttribute(string displayName, EngineVersion engineVersion, Platform platform)
        {
            DisplayName = displayName;
            EngineVersion = engineVersion;
            Platform = platform;
        }


        /// <summary>
        /// The game mode display name
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// The game engine version
        /// </summary>
        public EngineVersion EngineVersion { get; }

        /// <summary>
        /// The platform
        /// </summary>
        public Platform Platform { get; }
    }
}