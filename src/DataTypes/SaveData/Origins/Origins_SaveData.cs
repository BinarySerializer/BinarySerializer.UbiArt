using static BinarySerializer.UbiArt.Origins_SaveData;

namespace BinarySerializer.UbiArt
{
    // TODO: Move classes into separate files
    // TODO: Support multiple versions since they have similar (same?) save formats. Currently this supports the PC version.

    /// <summary>
    /// The save file data used for Rayman Origins
    /// </summary>
    public class Origins_SaveData : SaveGameFile<Ray_PersistentGameData_Universe>
    {
        #region Save Data Classes

        /// <summary>
        /// The main save data for a Rayman Origins save slot
        /// </summary>
        public class Ray_PersistentGameData_Universe : BinarySerializable
        {
            /// <summary>
            /// The save data for each level
            /// </summary>
            public UbiArtObjKeyObjValuePair<StringID, Generic<PersistentGameData_Level>>[] Levels { get; set; }

            public SaveSession Rewards { get; set; }

            public Ray_PersistentGameData_Score Score { get; set; }

            public Ray_PersistentGameData_WorldMap WorldMapData { get; set; }

            public Ray_PersistentGameData_UniverseTracking TrackingData { get; set; }

            public AbsoluteObjectPath[] DiscoveredCageMapList { get; set; }

            public uint TeethReturned { get; set; }

            public StringID UsedPlayerIDInfo { get; set; }

            public int SprintTutorialDisabled { get; set; }

            public uint CostumeLastPrice { get; set; }

            public StringID[] CostumesUsed { get; set; }

            public float Nintendo3DS_PlayTime { get; set; } // Not 100% sure if this is correct
            public float Nintendo3DS_SfxVolume { get; set; }
            public float Nintendo3DS_MusicVolume { get; set; }
            public bool Nintendo3DS_PlayIntro { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();

                Levels = s.SerializeUbiArtObjectArray<UbiArtObjKeyObjValuePair<StringID, Generic<PersistentGameData_Level>>>(Levels, name: nameof(Levels));
                Rewards = s.SerializeObject<SaveSession>(Rewards, name: nameof(Rewards));
                Score = s.SerializeObject<Ray_PersistentGameData_Score>(Score, name: nameof(Score));
                WorldMapData = s.SerializeObject<Ray_PersistentGameData_WorldMap>(WorldMapData, name: nameof(WorldMapData));
                TrackingData = s.SerializeObject<Ray_PersistentGameData_UniverseTracking>(TrackingData, name: nameof(TrackingData));
                DiscoveredCageMapList = s.SerializeUbiArtObjectArray<AbsoluteObjectPath>(DiscoveredCageMapList, name: nameof(DiscoveredCageMapList));
                TeethReturned = s.Serialize<uint>(TeethReturned, name: nameof(TeethReturned));
                UsedPlayerIDInfo = s.SerializeObject<StringID>(UsedPlayerIDInfo, name: nameof(UsedPlayerIDInfo));
                SprintTutorialDisabled = s.Serialize<int>(SprintTutorialDisabled, name: nameof(SprintTutorialDisabled));

                if (settings.Platform == Platform.Nintendo3DS)
                    Nintendo3DS_PlayTime = s.Serialize<float>(Nintendo3DS_PlayTime, name: nameof(Nintendo3DS_PlayTime));
                
                CostumeLastPrice = s.Serialize<uint>(CostumeLastPrice, name: nameof(CostumeLastPrice));
                CostumesUsed = s.SerializeUbiArtObjectArray<StringID>(CostumesUsed, name: nameof(CostumesUsed));

                if (settings.Platform == Platform.Nintendo3DS)
                {
                    Nintendo3DS_SfxVolume = s.Serialize<float>(Nintendo3DS_SfxVolume, name: nameof(Nintendo3DS_SfxVolume));
                    Nintendo3DS_MusicVolume = s.Serialize<float>(Nintendo3DS_MusicVolume, name: nameof(Nintendo3DS_MusicVolume));
                    Nintendo3DS_PlayIntro = s.SerializeUbiArtBool(Nintendo3DS_PlayIntro, name: nameof(Nintendo3DS_PlayIntro));
                }
            }
        }

        public class PersistentGameData_Level : BinarySerializable
        {
            public UbiArtObjKeyObjValuePair<StringID, Generic<Ray_PersistentGameData_ISD>>[] ISDs { get; set; }

            public PackedObjectPath[] CageMapPassedDoors { get; set; }

            public uint WonChallenges { get; set; }

            public SPOT_STATE LevelState { get; set; }

            public uint BestTimeAttack { get; set; }

            public uint BestLumAttack { get; set; }

            public bool HasWarning { get; set; }

            public bool IsSkipped { get; set; }

            public Ray_PersistentGameData_LevelTracking Trackingdata { get; set; }

            public class Ray_PersistentGameData_ISD : BinarySerializable
            {
                public PackedObjectPath[] PickedUpLums { get; set; }

                public PackedObjectPath[] TakenTooth { get; set; }

                public PackedObjectPath[] AlreadySeenCutScenes { get; set; }

                public uint FoundRelicMask { get; set; }

                public uint FoundCageMask { get; set; }

                public override void SerializeImpl(SerializerObject s)
                {
                    PickedUpLums = s.SerializeUbiArtObjectArray<PackedObjectPath>(PickedUpLums, name: nameof(PickedUpLums));
                    TakenTooth = s.SerializeUbiArtObjectArray<PackedObjectPath>(TakenTooth, name: nameof(TakenTooth));
                    AlreadySeenCutScenes = s.SerializeUbiArtObjectArray<PackedObjectPath>(AlreadySeenCutScenes, name: nameof(AlreadySeenCutScenes));
                    FoundRelicMask = s.Serialize<uint>(FoundRelicMask, name: nameof(FoundRelicMask));
                    FoundCageMask = s.Serialize<uint>(FoundCageMask, name: nameof(FoundCageMask));
                }
            }

            public class Ray_PersistentGameData_LevelTracking : BinarySerializable
            {
                public uint RunCount { get; set; }

                public uint ChallengeTimeAttackCount { get; set; }

                public uint ChallengeHidden1 { get; set; }

                public uint ChallengeHidden2 { get; set; }

                public uint ChallengeCage { get; set; }

                public float FirstTimeLevelCompleted { get; set; }

                public uint ChallengeLumsStage1 { get; set; }

                public uint ChallengeLumsStage2 { get; set; }

                public override void SerializeImpl(SerializerObject s)
                {
                    RunCount = s.Serialize<uint>(RunCount, name: nameof(RunCount));
                    ChallengeTimeAttackCount = s.Serialize<uint>(ChallengeTimeAttackCount, name: nameof(ChallengeTimeAttackCount));
                    ChallengeHidden1 = s.Serialize<uint>(ChallengeHidden1, name: nameof(ChallengeHidden1));
                    ChallengeHidden2 = s.Serialize<uint>(ChallengeHidden2, name: nameof(ChallengeHidden2));
                    ChallengeCage = s.Serialize<uint>(ChallengeCage, name: nameof(ChallengeCage));
                    FirstTimeLevelCompleted = s.Serialize<float>(FirstTimeLevelCompleted, name: nameof(FirstTimeLevelCompleted));
                    ChallengeLumsStage1 = s.Serialize<uint>(ChallengeLumsStage1, name: nameof(ChallengeLumsStage1));
                    ChallengeLumsStage2 = s.Serialize<uint>(ChallengeLumsStage2, name: nameof(ChallengeLumsStage2));
                }
            }

            public override void SerializeImpl(SerializerObject s)
            {
                ISDs = s.SerializeUbiArtObjectArray<UbiArtObjKeyObjValuePair<StringID, Generic<Ray_PersistentGameData_ISD>>>(ISDs, name: nameof(ISDs));
                CageMapPassedDoors = s.SerializeUbiArtObjectArray<PackedObjectPath>(CageMapPassedDoors, name: nameof(CageMapPassedDoors));
                WonChallenges = s.Serialize<uint>(WonChallenges, name: nameof(WonChallenges));
                LevelState = s.Serialize<SPOT_STATE>(LevelState, name: nameof(LevelState));
                BestTimeAttack = s.Serialize<uint>(BestTimeAttack, name: nameof(BestTimeAttack));
                BestLumAttack = s.Serialize<uint>(BestLumAttack, name: nameof(BestLumAttack));
                HasWarning = s.SerializeUbiArtBool(HasWarning, name: nameof(HasWarning));
                IsSkipped = s.SerializeUbiArtBool(IsSkipped, name: nameof(IsSkipped));
                Trackingdata = s.SerializeObject<Ray_PersistentGameData_LevelTracking>(Trackingdata, name: nameof(Ray_PersistentGameData_LevelTracking));
            }
        }

        public class SaveSession : BinarySerializable
        {
            public float[] Tags { get; set; }

            public float[] Timers { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Tags = s.SerializeUbiArtArray<float>(Tags, name: nameof(Tags));
                Timers = s.SerializeUbiArtArray<float>(Timers, name: nameof(Timers));
            }
        }

        public class Ray_PersistentGameData_Score : BinarySerializable
        {
            public uint[] LumCount { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                LumCount = s.SerializeUbiArtArray<uint>(LumCount, name: nameof(LumCount));
            }
        }

        public class Ray_PersistentGameData_WorldMap : BinarySerializable
        {
            public UbiArtObjKeyObjValuePair<StringID, WorldInfo>[] WorldsInfo { get; set; }

            public ObjectPath CurrentWorld { get; set; }

            public StringID CurrentWorldTag { get; set; }

            public ObjectPath CurrentLevel { get; set; }

            public StringID CurrentLevelTag { get; set; }

            public class WorldInfo : BinarySerializable
            {
                public SPOT_STATE State { get; set; }

                public bool HasWarning { get; set; }

                public override void SerializeImpl(SerializerObject s)
                {
                    State = s.Serialize<SPOT_STATE>(State, name: nameof(State));
                    HasWarning = s.SerializeUbiArtBool(HasWarning, name: nameof(HasWarning));
                }
            }

            public override void SerializeImpl(SerializerObject s)
            {
                WorldsInfo = s.SerializeUbiArtObjectArray<UbiArtObjKeyObjValuePair<StringID, WorldInfo>>(WorldsInfo, name: nameof(WorldsInfo));
                CurrentWorld = s.SerializeObject<ObjectPath>(CurrentWorld, name: nameof(CurrentWorld));
                CurrentWorldTag = s.SerializeObject<StringID>(CurrentWorldTag, name: nameof(CurrentWorldTag));
                CurrentLevel = s.SerializeObject<ObjectPath>(CurrentLevel, name: nameof(CurrentLevel));
                CurrentLevelTag = s.SerializeObject<StringID>(CurrentLevelTag, name: nameof(CurrentLevelTag));
            }
        }

        public enum SPOT_STATE : uint
        {
            CLOSED = 0,
            NEW = 1,
            CANNOT_ENTER = 2,
            OPEN = 3,
            COMPLETED = 4,
        }

        public class Ray_PersistentGameData_UniverseTracking : BinarySerializable
        {
            public float[] Timers { get; set; }

            public uint[] PafCounter { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Timers = s.SerializeUbiArtArray<float>(Timers, name: nameof(Timers));
                PafCounter = s.SerializeUbiArtArray<uint>(PafCounter, name: nameof(PafCounter));
            }
        }

        public class PackedObjectPath : BinarySerializable
        {
            public long Id { get; set; }

            public uint PathCode { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Id = s.Serialize<long>(Id, name: nameof(Id));
                PathCode = s.Serialize<uint>(PathCode, name: nameof(PathCode));
            }
        }

        public class AbsoluteObjectPath : BinarySerializable
        {
            public PackedObjectPath PackedObjectPath { get; set; }

            public uint LevelCRC { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                PackedObjectPath = s.SerializeObject<PackedObjectPath>(PackedObjectPath, name: nameof(PackedObjectPath));
                LevelCRC = s.Serialize<uint>(LevelCRC, name: nameof(LevelCRC));
            }
        }

        #endregion
    }
}