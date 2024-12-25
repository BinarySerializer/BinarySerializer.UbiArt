using System.Reflection;
using static BinarySerializer.UbiArt.Legends_SaveData;

namespace BinarySerializer.UbiArt
{
    // TODO: Move classes into separate files

    /// <summary>
    /// The save file data used for Rayman Legends
    /// </summary>
    public class Legends_SaveData : SaveGameFile<RO2_PersistentGameData_Universe>
    {
        #region Save Data Classes

        /// <summary>
        /// The main save data for a Rayman Legends save slot
        /// </summary>
        public class RO2_PersistentGameData_Universe : BinarySerializable
        {
            /// <summary>
            /// The save data for each level
            /// </summary>
            public UbiArtObjKeyObjValuePair<StringID, Generic<PersistentGameData_Level>>[] Levels { get; set; }

            public SaveSession Rewards { get; set; }

            public PersistentGameData_Score Score { get; set; }

            public ProfileData Profile { get; set; }

            public PersistentGameData_BubbleDreamerData BubbleDreamer { get; set; }

            public int[] UnlockedPets { get; set; }

            public PetRewardData[] PetsDailyReward { get; set; }

            public St_petCups[] UnlockedCupsForPets { get; set; }

            public uint GivenPetCount { get; set; }

            public bool NewPetsUnlocked { get; set; }

            public bool FirstPetShown { get; set; }

            public bool HasShownMessageAllPet { get; set; }

            public Message[] Messages { get; set; }

            public uint MessagesTotalCount { get; set; }

            public DateTime Messages_onlineDate { get; set; }

            public DateTime Messages_localDate { get; set; }

            public uint Messages_readDrcCount { get; set; }

            public uint Messages_interactDrcCount { get; set; }

            public uint Messages_lastSeenMessageHandle { get; set; }

            public uint Messages_tutoCount { get; set; }

            public uint Messages_drcCountSinceLastInteract { get; set; }

            public uint PlayerCard_displayedCount { get; set; }

            public bool PlayerCard_tutoSeen { get; set; }

            public bool GameCompleted { get; set; }

            public uint TimeToCompleteGameInSec { get; set; }

            public uint TimeSpendInGameInSec { get; set; }

            public uint TimeSpendInDockedInSec { get; set; }

            public uint TimeSpendInHandheldInSec { get; set; }

            public uint TimeSpendInTableTopInSec { get; set; }

            public uint TeensiesBonusCounter { get; set; }

            public uint LuckyTicketsCounter { get; set; }

            public uint LuckyTicketLevelCount { get; set; }

            public uint RetroMapUnlockedCounter { get; set; }

            public StringID[] MrDarkUnlockCount { get; set; }

            public uint CatchEmAllIndex { get; set; }

            public StringID[] NewCostumes { get; set; }

            public StringID[] CostumeUnlockSeen { get; set; }

            public StringID[] RetroUnlocks { get; set; }

            public UnlockedDoor[] NewUnlockedDoor { get; set; }

            public RO2_LuckyTicketReward[] LuckyTicketRewardList { get; set; }

            public NodeDataStruct[] NodeData { get; set; }

            public uint LuckyTicketsRewardGivenCounter { get; set; }

            public uint ConsecutiveLuckyTicketCount { get; set; }

            public uint TicketReminderMessageCount { get; set; }

            public uint DisplayGhosts { get; set; }

            public bool UplayDoneAction0 { get; set; }

            public bool UplayDoneAction1 { get; set; }

            public bool UplayDoneAction2 { get; set; }

            public bool UplayDoneAction3 { get; set; }
            
            public bool UplayDoneAction4 { get; set; }

            public bool UplayDoneReward0 { get; set; }

            public bool UplayDoneReward1 { get; set; }

            public bool UplayDoneReward2 { get; set; }

            public bool UplayDoneReward3 { get; set; }
            
            public bool UplayDoneReward4 { get; set; }

            public StringID[] PlayedDiamondCupSequence { get; set; }

            public StringID[] Costumes { get; set; }

            public uint[] PlayedChallenge { get; set; }

            public StringID[] PlayedInvasion { get; set; }

            public uint TvOffOptionEnabledNb { get; set; }

            public uint TvOffOptionActivatedTime { get; set; }

            public bool BarbaraCostumeUnlockSeen { get; set; }

            public StringID[] WorldUnlockMessagesSeen { get; set; }

            public bool RetroWorldUnlockMessageSeen { get; set; }

            public bool MurphyGalleryUnlockMessageSeen { get; set; }

            public bool MurphyWorldUnlockMessageSeen { get; set; }

            public uint MurphyLevelDoneCount { get; set; }

            public bool FreedAllTeensiesMessageSeen { get; set; }

            public bool MisterDarkCompletionMessageSeen { get; set; }

            public bool FirstInvasionMessageSeen { get; set; }

            public bool InvitationTutoSeen { get; set; }

            public bool MessageSeen8Bit { get; set; }

            public bool ChallengeWorldUnlockMessageSeen { get; set; }

            public StringID[] DoorUnlockMessageSeen { get; set; }

            public StringID[] DoorUnlockDRCMessageRequired { get; set; }

            public StringID LuckyTicketRewardWorldName { get; set; }

            public bool ShareScreenTutoFulfilled { get; set; }

            public bool IsUGCMiiverseWarningSet { get; set; }

            public int Reward39Failed { get; set; }

            public string UnlockPrivilegesData { get; set; }

            public int IsDemoRewardChecked { get; set; }

            public PrisonerData PrisonerDataDummy { get; set; }

            public PersistentGameData_Level PersistentGameDataLevelDummy { get; set; }

            public Message MessageDummy { get; set; }

            public UnlockedDoor UnlockedDoorDummy { get; set; }

            public PersistentGameData_BubbleDreamerData BubbleDreamerDataDummy { get; set; }

            public NodeDataStruct DummmyNodeData { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Levels = s.SerializeUbiArtObjectArray<UbiArtObjKeyObjValuePair<StringID, Generic<PersistentGameData_Level>>>(Levels, name: nameof(Levels));
                Rewards = s.SerializeObject<SaveSession>(Rewards, name: nameof(Rewards));
                Score = s.SerializeObject<PersistentGameData_Score>(Score, name: nameof(Score));
                Profile = s.SerializeObject<ProfileData>(Profile, name: nameof(Profile));
                BubbleDreamer = s.SerializeObject<PersistentGameData_BubbleDreamerData>(BubbleDreamer, name: nameof(BubbleDreamer));
                UnlockedPets = s.SerializeUbiArtArray<int>(UnlockedPets, name: nameof(UnlockedPets));
                PetsDailyReward = s.SerializeUbiArtObjectArray<PetRewardData>(PetsDailyReward, name: nameof(PetsDailyReward));
                UnlockedCupsForPets = s.SerializeUbiArtObjectArray<St_petCups>(UnlockedCupsForPets, name: nameof(UnlockedCupsForPets));
                GivenPetCount = s.Serialize<uint>(GivenPetCount, name: nameof(GivenPetCount));
                NewPetsUnlocked = s.SerializeUbiArtBool(NewPetsUnlocked, name: nameof(NewPetsUnlocked));
                FirstPetShown = s.SerializeUbiArtBool(FirstPetShown, name: nameof(FirstPetShown));
                HasShownMessageAllPet = s.SerializeUbiArtBool(HasShownMessageAllPet, name: nameof(HasShownMessageAllPet));
                Messages = s.SerializeUbiArtObjectArray<Message>(Messages, name: nameof(Messages));
                MessagesTotalCount = s.Serialize<uint>(MessagesTotalCount, name: nameof(MessagesTotalCount));
                Messages_onlineDate = s.SerializeObject<DateTime>(Messages_onlineDate, name: nameof(Messages_onlineDate));
                Messages_localDate = s.SerializeObject<DateTime>(Messages_localDate, name: nameof(Messages_localDate));
                Messages_readDrcCount = s.Serialize<uint>(Messages_readDrcCount, name: nameof(Messages_readDrcCount));
                Messages_interactDrcCount = s.Serialize<uint>(Messages_interactDrcCount, name: nameof(Messages_interactDrcCount));
                Messages_lastSeenMessageHandle = s.Serialize<uint>(Messages_lastSeenMessageHandle, name: nameof(Messages_lastSeenMessageHandle));
                Messages_tutoCount = s.Serialize<uint>(Messages_tutoCount, name: nameof(Messages_tutoCount));
                Messages_drcCountSinceLastInteract = s.Serialize<uint>(Messages_drcCountSinceLastInteract, name: nameof(Messages_drcCountSinceLastInteract));
                PlayerCard_displayedCount = s.Serialize<uint>(PlayerCard_displayedCount, name: nameof(PlayerCard_displayedCount));
                PlayerCard_tutoSeen = s.SerializeUbiArtBool(PlayerCard_tutoSeen, name: nameof(PlayerCard_tutoSeen));
                GameCompleted = s.SerializeUbiArtBool(GameCompleted, name: nameof(GameCompleted));
                TimeToCompleteGameInSec = s.Serialize<uint>(TimeToCompleteGameInSec, name: nameof(TimeToCompleteGameInSec));
                TimeSpendInGameInSec = s.Serialize<uint>(TimeSpendInGameInSec, name: nameof(TimeSpendInGameInSec));

                if (s.GetRequiredSettings<UbiArtSettings>().Platform == Platform.NintendoSwitch)
                {
                    TimeSpendInDockedInSec = s.Serialize<uint>(TimeSpendInDockedInSec, name: nameof(TimeSpendInDockedInSec));
                    TimeSpendInHandheldInSec = s.Serialize<uint>(TimeSpendInHandheldInSec, name: nameof(TimeSpendInHandheldInSec));
                    TimeSpendInTableTopInSec = s.Serialize<uint>(TimeSpendInTableTopInSec, name: nameof(TimeSpendInTableTopInSec));
                }

                TeensiesBonusCounter = s.Serialize<uint>(TeensiesBonusCounter, name: nameof(TeensiesBonusCounter));
                LuckyTicketsCounter = s.Serialize<uint>(LuckyTicketsCounter, name: nameof(LuckyTicketsCounter));
                LuckyTicketLevelCount = s.Serialize<uint>(LuckyTicketLevelCount, name: nameof(LuckyTicketLevelCount));
                RetroMapUnlockedCounter = s.Serialize<uint>(RetroMapUnlockedCounter, name: nameof(RetroMapUnlockedCounter));
                MrDarkUnlockCount = s.SerializeUbiArtObjectArray<StringID>(MrDarkUnlockCount, name: nameof(MrDarkUnlockCount));
                CatchEmAllIndex = s.Serialize<uint>(CatchEmAllIndex, name: nameof(CatchEmAllIndex));
                NewCostumes = s.SerializeUbiArtObjectArray<StringID>(NewCostumes, name: nameof(NewCostumes));
                CostumeUnlockSeen = s.SerializeUbiArtObjectArray<StringID>(CostumeUnlockSeen, name: nameof(CostumeUnlockSeen));
                RetroUnlocks = s.SerializeUbiArtObjectArray<StringID>(RetroUnlocks, name: nameof(RetroUnlocks));
                NewUnlockedDoor = s.SerializeUbiArtObjectArray<UnlockedDoor>(NewUnlockedDoor, name: nameof(NewUnlockedDoor));
                LuckyTicketRewardList = s.SerializeUbiArtObjectArray<RO2_LuckyTicketReward>(LuckyTicketRewardList, name: nameof(LuckyTicketRewardList));
                NodeData = s.SerializeUbiArtObjectArray<NodeDataStruct>(NodeData, name: nameof(NodeData));
                LuckyTicketsRewardGivenCounter = s.Serialize<uint>(LuckyTicketsRewardGivenCounter, name: nameof(LuckyTicketsRewardGivenCounter));
                ConsecutiveLuckyTicketCount = s.Serialize<uint>(ConsecutiveLuckyTicketCount, name: nameof(ConsecutiveLuckyTicketCount));
                TicketReminderMessageCount = s.Serialize<uint>(TicketReminderMessageCount, name: nameof(TicketReminderMessageCount));
                DisplayGhosts = s.Serialize<uint>(DisplayGhosts, name: nameof(DisplayGhosts));
                UplayDoneAction0 = s.SerializeUbiArtBool(UplayDoneAction0, name: nameof(UplayDoneAction0));
                UplayDoneAction1 = s.SerializeUbiArtBool(UplayDoneAction1, name: nameof(UplayDoneAction1));
                UplayDoneAction2 = s.SerializeUbiArtBool(UplayDoneAction2, name: nameof(UplayDoneAction2));
                UplayDoneAction3 = s.SerializeUbiArtBool(UplayDoneAction3, name: nameof(UplayDoneAction3));

                if (s.GetRequiredSettings<UbiArtSettings>().Platform == Platform.NintendoSwitch)
                    UplayDoneAction4 = s.SerializeUbiArtBool(UplayDoneAction4, name: nameof(UplayDoneAction4));

                UplayDoneReward0 = s.SerializeUbiArtBool(UplayDoneReward0, name: nameof(UplayDoneReward0));
                UplayDoneReward1 = s.SerializeUbiArtBool(UplayDoneReward1, name: nameof(UplayDoneReward1));
                UplayDoneReward2 = s.SerializeUbiArtBool(UplayDoneReward2, name: nameof(UplayDoneReward2));
                UplayDoneReward3 = s.SerializeUbiArtBool(UplayDoneReward3, name: nameof(UplayDoneReward3));

                if (s.GetRequiredSettings<UbiArtSettings>().Platform == Platform.NintendoSwitch)
                    UplayDoneReward4 = s.SerializeUbiArtBool(UplayDoneReward4, name: nameof(UplayDoneReward4));

                PlayedDiamondCupSequence = s.SerializeUbiArtObjectArray<StringID>(PlayedDiamondCupSequence, name: nameof(PlayedDiamondCupSequence));
                Costumes = s.SerializeUbiArtObjectArray<StringID>(Costumes, name: nameof(Costumes));
                PlayedChallenge = s.SerializeUbiArtArray<uint>(PlayedChallenge, name: nameof(PlayedChallenge));
                PlayedInvasion = s.SerializeUbiArtObjectArray<StringID>(PlayedInvasion, name: nameof(PlayedInvasion));
                TvOffOptionEnabledNb = s.Serialize<uint>(TvOffOptionEnabledNb, name: nameof(TvOffOptionEnabledNb));
                TvOffOptionActivatedTime = s.Serialize<uint>(TvOffOptionActivatedTime, name: nameof(TvOffOptionActivatedTime));
                BarbaraCostumeUnlockSeen = s.SerializeUbiArtBool(BarbaraCostumeUnlockSeen, name: nameof(BarbaraCostumeUnlockSeen));
                WorldUnlockMessagesSeen = s.SerializeUbiArtObjectArray<StringID>(WorldUnlockMessagesSeen, name: nameof(WorldUnlockMessagesSeen));
                RetroWorldUnlockMessageSeen = s.SerializeUbiArtBool(RetroWorldUnlockMessageSeen, name: nameof(RetroWorldUnlockMessageSeen));

                if (s.GetRequiredSettings<UbiArtSettings>().Platform == Platform.NintendoSwitch)
                {
                    MurphyGalleryUnlockMessageSeen = s.SerializeUbiArtBool(MurphyGalleryUnlockMessageSeen, name: nameof(MurphyGalleryUnlockMessageSeen));
                    MurphyWorldUnlockMessageSeen = s.SerializeUbiArtBool(MurphyWorldUnlockMessageSeen, name: nameof(MurphyWorldUnlockMessageSeen));
                    MurphyLevelDoneCount = s.Serialize<uint>(MurphyLevelDoneCount, name: nameof(MurphyLevelDoneCount));
                }

                FreedAllTeensiesMessageSeen = s.SerializeUbiArtBool(FreedAllTeensiesMessageSeen, name: nameof(FreedAllTeensiesMessageSeen));
                MisterDarkCompletionMessageSeen = s.SerializeUbiArtBool(MisterDarkCompletionMessageSeen, name: nameof(MisterDarkCompletionMessageSeen));
                FirstInvasionMessageSeen = s.SerializeUbiArtBool(FirstInvasionMessageSeen, name: nameof(FirstInvasionMessageSeen));
                InvitationTutoSeen = s.SerializeUbiArtBool(InvitationTutoSeen, name: nameof(InvitationTutoSeen));
                MessageSeen8Bit = s.SerializeUbiArtBool(MessageSeen8Bit, name: nameof(MessageSeen8Bit));
                ChallengeWorldUnlockMessageSeen = s.SerializeUbiArtBool(ChallengeWorldUnlockMessageSeen, name: nameof(ChallengeWorldUnlockMessageSeen));
                DoorUnlockMessageSeen = s.SerializeUbiArtObjectArray<StringID>(DoorUnlockMessageSeen, name: nameof(DoorUnlockMessageSeen));
                DoorUnlockDRCMessageRequired = s.SerializeUbiArtObjectArray<StringID>(DoorUnlockDRCMessageRequired, name: nameof(DoorUnlockDRCMessageRequired));
                LuckyTicketRewardWorldName = s.SerializeObject<StringID>(LuckyTicketRewardWorldName, name: nameof(LuckyTicketRewardWorldName));

                if (s.GetRequiredSettings<UbiArtSettings>().Platform == Platform.NintendoSwitch)
                    ShareScreenTutoFulfilled = s.SerializeUbiArtBool(ShareScreenTutoFulfilled, name: nameof(ShareScreenTutoFulfilled));

                IsUGCMiiverseWarningSet = s.SerializeUbiArtBool(IsUGCMiiverseWarningSet, name: nameof(IsUGCMiiverseWarningSet));
                Reward39Failed = s.Serialize<int>(Reward39Failed, name: nameof(Reward39Failed));
                UnlockPrivilegesData = s.SerializeObject<String8>(UnlockPrivilegesData, name: nameof(UnlockPrivilegesData));
                IsDemoRewardChecked = s.Serialize<int>(IsDemoRewardChecked, name: nameof(IsDemoRewardChecked));
                PrisonerDataDummy = s.SerializeObject<PrisonerData>(PrisonerDataDummy, name: nameof(PrisonerDataDummy));
                PersistentGameDataLevelDummy = s.SerializeObject<PersistentGameData_Level>(PersistentGameDataLevelDummy, name: nameof(PersistentGameDataLevelDummy));
                MessageDummy = s.SerializeObject<Message>(MessageDummy, name: nameof(MessageDummy));
                UnlockedDoorDummy = s.SerializeObject<UnlockedDoor>(UnlockedDoorDummy, name: nameof(UnlockedDoorDummy));
                BubbleDreamerDataDummy = s.SerializeObject<PersistentGameData_BubbleDreamerData>(BubbleDreamerDataDummy, name: nameof(BubbleDreamerDataDummy));
                DummmyNodeData = s.SerializeObject<NodeDataStruct>(DummmyNodeData, name: nameof(DummmyNodeData));
            }
        }

        public class Message : BinarySerializable
        {
            public uint Message_handle { get; set; }

            public uint Type { get; set; }

            public DateTime Onlinedate { get; set; }

            public DateTime LocalDate { get; set; }

            public bool Sender { get; set; }

            public uint PersistentSeconds { get; set; }

            public SmartLocId Title { get; set; }

            public SmartLocId Body { get; set; }

            public bool IsPrompt { get; set; }

            public bool IsDrc { get; set; }

            public bool HasBeenRead { get; set; }

            public bool IsOnline { get; set; }

            public bool RemoveAfterRead { get; set; }

            public bool HasBeenInteract { get; set; }

            public bool RemoveAfterInteract { get; set; }

            public bool LockedAfterInteract { get; set; }

            public SmartLocId[] Buttons { get; set; }

            public Attribute[] Attributes { get; set; }

            public Marker[] Markers { get; set; }

            public class Marker : BinarySerializable
            {
                public SmartLocId LocId { get; set; }

                public uint Color { get; set; }

                public float FontSize { get; set; }

                public override void SerializeImpl(SerializerObject s)
                {
                    LocId = s.SerializeObject<SmartLocId>(LocId, name: nameof(LocId));
                    Color = s.Serialize<uint>(Color, name: nameof(Color));
                    FontSize = s.Serialize<float>(FontSize, name: nameof(FontSize));
                }
            }

            public class Attribute : BinarySerializable
            {
                public uint Type { get; set; }

                public uint Value { get; set; }

                public override void SerializeImpl(SerializerObject s)
                {
                    Type = s.Serialize<uint>(Type, name: nameof(Type));
                    Value = s.Serialize<uint>(Value, name: nameof(Value));
                }
            }

            public override void SerializeImpl(SerializerObject s)
            {
                Message_handle = s.Serialize<uint>(Message_handle, name: nameof(Message_handle));
                Type = s.Serialize<uint>(Type, name: nameof(Type));
                Onlinedate = s.SerializeObject<DateTime>(Onlinedate, name: nameof(Onlinedate));
                LocalDate = s.SerializeObject<DateTime>(LocalDate, name: nameof(LocalDate));

                if (s.GetRequiredSettings<UbiArtSettings>().Platform == Platform.NintendoSwitch)
                    Sender = s.SerializeUbiArtBool(Sender, name: nameof(Sender));
                
                PersistentSeconds = s.Serialize<uint>(PersistentSeconds, name: nameof(PersistentSeconds));
                Title = s.SerializeObject<SmartLocId>(Title, name: nameof(Title));
                Body = s.SerializeObject<SmartLocId>(Body, name: nameof(Body));
                IsPrompt = s.SerializeUbiArtBool(IsPrompt, name: nameof(IsPrompt));
                IsDrc = s.SerializeUbiArtBool(IsDrc, name: nameof(IsDrc));
                HasBeenRead = s.SerializeUbiArtBool(HasBeenRead, name: nameof(HasBeenRead));
                IsOnline = s.SerializeUbiArtBool(IsOnline, name: nameof(IsOnline));
                RemoveAfterRead = s.SerializeUbiArtBool(RemoveAfterRead, name: nameof(RemoveAfterRead));
                HasBeenInteract = s.SerializeUbiArtBool(HasBeenInteract, name: nameof(HasBeenInteract));
                RemoveAfterInteract = s.SerializeUbiArtBool(RemoveAfterInteract, name: nameof(RemoveAfterInteract));
                LockedAfterInteract = s.SerializeUbiArtBool(LockedAfterInteract, name: nameof(LockedAfterInteract));
                Buttons = s.SerializeUbiArtObjectArray<SmartLocId>(Buttons, name: nameof(Buttons));
                Attributes = s.SerializeUbiArtObjectArray<Attribute>(Attributes, name: nameof(Attributes));
                Markers = s.SerializeUbiArtObjectArray<Marker>(Markers, name: nameof(Markers));
            }
        }

        public class PersistentGameData_Level : BinarySerializable
        {
            #region Public Properties

            public StringID Id { get; set; }

            public uint BestLumsTaken { get; set; }

            public float BestDistance { get; set; }

            public float BestTime { get; set; }

            public PrisonerData[] FreedPrisoners { get; set; }

            public uint Cups { get; set; }

            public uint Medals { get; set; }

            public bool Completed { get; set; }

            public bool IsVisited { get; set; }

            public bool BestTimeSent { get; set; }

            public uint Type { get; set; }

            public uint LuckyTicketsLeft { get; set; }

            public ObjectPath[] SequenceAlreadySeen { get; set; }

            public int OnlineSynced { get; set; }

            #endregion

            #region Public Methods

            public override void SerializeImpl(SerializerObject s)
            {
                Id = s.SerializeObject<StringID>(Id, name: nameof(Id));
                BestLumsTaken = s.Serialize<uint>(BestLumsTaken, name: nameof(BestLumsTaken));
                BestDistance = s.Serialize<float>(BestDistance, name: nameof(BestDistance));
                BestTime = s.Serialize<float>(BestTime, name: nameof(BestTime));
                FreedPrisoners = s.SerializeUbiArtObjectArray<PrisonerData>(FreedPrisoners, name: nameof(FreedPrisoners));
                Cups = s.Serialize<uint>(Cups, name: nameof(Cups));
                Medals = s.Serialize<uint>(Medals, name: nameof(Medals));
                Completed = s.SerializeUbiArtBool(Completed, name: nameof(Completed));
                IsVisited = s.SerializeUbiArtBool(IsVisited, name: nameof(IsVisited));
                BestTimeSent = s.SerializeUbiArtBool(BestTimeSent, name: nameof(BestTimeSent));
                Type = s.Serialize<uint>(Type, name: nameof(Type));
                LuckyTicketsLeft = s.Serialize<uint>(LuckyTicketsLeft, name: nameof(LuckyTicketsLeft));
                SequenceAlreadySeen = s.SerializeUbiArtObjectArray<ObjectPath>(SequenceAlreadySeen, name: nameof(SequenceAlreadySeen));
                OnlineSynced = s.Serialize<int>(OnlineSynced, name: nameof(OnlineSynced));
            }

            #endregion
        }

        public class SaveSession : BinarySerializable
        {
            public float[] Tags { get; set; }

            public float[] Timers { get; set; }

            public UbiArtObjKeyValuePair<StringID, bool>[] RewardsState { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Tags = s.SerializeUbiArtArray<float>(Tags, name: nameof(Tags));
                Timers = s.SerializeUbiArtArray<float>(Timers, name: nameof(Timers));
                RewardsState = s.SerializeUbiArtObjectArray<UbiArtObjKeyValuePair<StringID, bool>>(RewardsState, name: nameof(RewardsState));
            }
        }

        public class PersistentGameData_Score : BinarySerializable
        {
            #region Public Properties

            public uint[] PlayersLumCount { get; set; }

            public uint[] TreasuresLumCount { get; set; }

            public int LocalLumsCount { get; set; }

            public int PendingLumsCount { get; set; }

            public int TempLumsCount { get; set; }

            #endregion

            #region Public Methods

            public override void SerializeImpl(SerializerObject s)
            {
                PlayersLumCount = s.SerializeUbiArtArray<uint>(PlayersLumCount, name: nameof(PlayersLumCount));
                TreasuresLumCount = s.SerializeUbiArtArray<uint>(TreasuresLumCount, name: nameof(TreasuresLumCount));
                LocalLumsCount = s.Serialize<int>(LocalLumsCount, name: nameof(LocalLumsCount));
                PendingLumsCount = s.Serialize<int>(PendingLumsCount, name: nameof(PendingLumsCount));
                TempLumsCount = s.Serialize<int>(TempLumsCount, name: nameof(TempLumsCount));
            }

            #endregion
        }

        public class ProfileData : BinarySerializable
        {
            public int Pid { get; set; }

            public string Name { get; set; }

            public uint StatusIcon { get; set; }

            public int Country { get; set; }

            public uint GlobalMedalsRank { get; set; }

            public uint GlobalMedalsMaxRank { get; set; }

            public uint DiamondMedals { get; set; }

            public uint GoldMedals { get; set; }

            public uint SilverMedals { get; set; }

            public uint BronzeMedals { get; set; }

            public PlayerStatsData PlayerStats { get; set; }

            public uint Costume { get; set; }

            public uint TotalChallengePlayed { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Pid = s.Serialize<int>(Pid, name: nameof(Pid));
                Name = s.SerializeObject<String8>(Name, name: nameof(Name));
                StatusIcon = s.Serialize<uint>(StatusIcon, name: nameof(StatusIcon));
                Country = s.Serialize<int>(Country, name: nameof(Country));
                GlobalMedalsRank = s.Serialize<uint>(GlobalMedalsRank, name: nameof(GlobalMedalsRank));
                GlobalMedalsMaxRank = s.Serialize<uint>(GlobalMedalsMaxRank, name: nameof(GlobalMedalsMaxRank));
                DiamondMedals = s.Serialize<uint>(DiamondMedals, name: nameof(DiamondMedals));
                GoldMedals = s.Serialize<uint>(GoldMedals, name: nameof(GoldMedals));
                SilverMedals = s.Serialize<uint>(SilverMedals, name: nameof(SilverMedals));
                BronzeMedals = s.Serialize<uint>(BronzeMedals, name: nameof(BronzeMedals));
                PlayerStats = s.SerializeObject<PlayerStatsData>(PlayerStats, name: nameof(PlayerStats));
                Costume = s.Serialize<uint>(Costume, name: nameof(Costume));
                TotalChallengePlayed = s.Serialize<uint>(TotalChallengePlayed, name: nameof(TotalChallengePlayed));
            }
        }

        public class PlayerStatsData : BinarySerializable
        {
            public PlayerStatsDataItem Lums { get; set; }

            public PlayerStatsDataItem Distance { get; set; }

            public PlayerStatsDataItem Kills { get; set; }

            public PlayerStatsDataItem Jumps { get; set; }

            public PlayerStatsDataItem Deaths { get; set; }

            public class PlayerStatsDataItem : BinarySerializable
            {
                public float Value { get; set; }

                public uint Rank { get; set; }

                public override void SerializeImpl(SerializerObject s)
                {
                    Value = s.Serialize<float>(Value, name: nameof(Value));
                    Rank = s.Serialize<uint>(Rank, name: nameof(Rank));
                }
            }

            public override void SerializeImpl(SerializerObject s)
            {
                Lums = s.SerializeObject<PlayerStatsDataItem>(Lums, name: nameof(Lums));
                Distance = s.SerializeObject<PlayerStatsDataItem>(Distance, name: nameof(Distance));
                Kills = s.SerializeObject<PlayerStatsDataItem>(Kills, name: nameof(Kills));
                Jumps = s.SerializeObject<PlayerStatsDataItem>(Jumps, name: nameof(Jumps));
                Deaths = s.SerializeObject<PlayerStatsDataItem>(Deaths, name: nameof(Deaths));
            }
        }

        public class PersistentGameData_BubbleDreamerData : BinarySerializable
        {
            public bool HasMet { get; set; }

            public bool UpdateRequested { get; set; }

            public bool HasWonPetCup { get; set; }

            public uint TeensyLocksOpened { get; set; }

            public uint ChallengeLocksOpened { get; set; }

            public uint TutoCount { get; set; }

            public bool[] DisplayQuoteStates { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                HasMet = s.SerializeUbiArtBool(HasMet, name: nameof(HasMet));
                UpdateRequested = s.SerializeUbiArtBool(UpdateRequested, name: nameof(UpdateRequested));
                HasWonPetCup = s.SerializeUbiArtBool(HasWonPetCup, name: nameof(HasWonPetCup));
                TeensyLocksOpened = s.Serialize<uint>(TeensyLocksOpened, name: nameof(TeensyLocksOpened));
                ChallengeLocksOpened = s.Serialize<uint>(ChallengeLocksOpened, name: nameof(ChallengeLocksOpened));
                TutoCount = s.Serialize<uint>(TutoCount, name: nameof(TutoCount));
                DisplayQuoteStates = s.SerializeUbiArtArray<bool>(DisplayQuoteStates, name: nameof(DisplayQuoteStates));
            }
        }

        public class PetRewardData : BinarySerializable
        {
            public uint LastSpawnDay { get; set; }

            public uint MaxRewardNb { get; set; }

            public uint RemainingRewards { get; set; }

            public uint RewardType { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                LastSpawnDay = s.Serialize<uint>(LastSpawnDay, name: nameof(LastSpawnDay));
                MaxRewardNb = s.Serialize<uint>(MaxRewardNb, name: nameof(MaxRewardNb));
                RemainingRewards = s.Serialize<uint>(RemainingRewards, name: nameof(RemainingRewards));
                RewardType = s.Serialize<uint>(RewardType, name: nameof(RewardType));
            }
        }

        public class St_petCups : BinarySerializable
        {
            public int Family { get; set; }

            public uint Cups { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Family = s.Serialize<int>(Family, name: nameof(Family));
                Cups = s.Serialize<uint>(Cups, name: nameof(Cups));
            }
        }

        public class UnlockedDoor : BinarySerializable
        {
            public StringID WorldTag { get; set; }

            public uint Type { get; set; }

            public bool IsNew { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                WorldTag = s.SerializeObject<StringID>(WorldTag, name: nameof(WorldTag));
                Type = s.Serialize<uint>(Type, name: nameof(Type));
                IsNew = s.SerializeUbiArtBool(IsNew, name: nameof(IsNew));
            }
        }

        public class RO2_LuckyTicketReward : BinarySerializable
        {
            public uint ID { get; set; }

            public uint Type { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                ID = s.Serialize<uint>(ID, name: nameof(ID));
                Type = s.Serialize<uint>(Type, name: nameof(Type));
            }
        }

        public class NodeDataStruct : BinarySerializable
        {
            public StringID Tag { get; set; }

            public bool UnteaseSeen { get; set; }

            public bool UnlockSeend { get; set; }

            public bool SentUnlockMessage { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Tag = s.SerializeObject<StringID>(Tag, name: nameof(Tag));
                UnteaseSeen = s.SerializeUbiArtBool(UnteaseSeen, name: nameof(UnteaseSeen));
                UnlockSeend = s.SerializeUbiArtBool(UnlockSeend, name: nameof(UnlockSeend));
                SentUnlockMessage = s.SerializeUbiArtBool(SentUnlockMessage, name: nameof(SentUnlockMessage));
            }
        }

        public class PrisonerData : BinarySerializable
        {
            public Path Path { get; set; }

            public bool IsFree { get; set; }

            public Index IndexType { get; set; }

            public Prisoner VisualType { get; set; }

            public enum Index : uint
            {
                Map1 = 0,
                Map2 = 1,
                Map3 = 2,
                Map4 = 3,
                Map5 = 4,
                Map6 = 5,
                Map7 = 6,
                Map8 = 7,
            }

            public enum Prisoner : uint
            {
                Soldier = 0,
                Baby = 1,
                Fool = 2,
                Princess = 3,
                Prince = 4,
                Queen = 5,
                King = 6,
            }

            public override void SerializeImpl(SerializerObject s)
            {
                Path = s.SerializeObject<Path>(Path, name: nameof(Path));
                IsFree = s.SerializeUbiArtBool(IsFree, name: nameof(IsFree));
                IndexType = s.Serialize<Index>(IndexType, name: nameof(IndexType));
                VisualType = s.Serialize<Prisoner>(VisualType, name: nameof(VisualType));
            }
        }

        #endregion
    }
}