using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.Models.Objects
{
    public partial class InGameModel
    {
        [JsonProperty("actions")]
        public List<List<Action>> Actions { get; set; }

        [JsonProperty("allowBattleBoost")]
        public bool AllowBattleBoost { get; set; }

        [JsonProperty("allowDuplicatePicks")]
        public bool AllowDuplicatePicks { get; set; }

        [JsonProperty("allowLockedEvents")]
        public bool AllowLockedEvents { get; set; }

        [JsonProperty("allowRerolling")]
        public bool AllowRerolling { get; set; }

        [JsonProperty("allowSkinSelection")]
        public bool AllowSkinSelection { get; set; }

        [JsonProperty("bans")]
        public Bans Bans { get; set; }

        [JsonProperty("benchChampionIds")]
        public List<object> BenchChampionIds { get; set; }

        [JsonProperty("benchEnabled")]
        public bool BenchEnabled { get; set; }

        [JsonProperty("boostableSkinCount")]
        public long BoostableSkinCount { get; set; }

        [JsonProperty("chatDetails")]
        public ChatDetails ChatDetails { get; set; }

        [JsonProperty("counter")]
        public long Counter { get; set; }

        [JsonProperty("entitledFeatureState")]
        public EntitledFeatureState EntitledFeatureState { get; set; }

        [JsonProperty("hasSimultaneousBans")]
        public bool HasSimultaneousBans { get; set; }

        [JsonProperty("hasSimultaneousPicks")]
        public bool HasSimultaneousPicks { get; set; }

        [JsonProperty("isCustomGame")]
        public bool IsCustomGame { get; set; }

        [JsonProperty("isSpectating")]
        public bool IsSpectating { get; set; }

        [JsonProperty("localPlayerCellId")]
        public long LocalPlayerCellId { get; set; }

        [JsonProperty("lockedEventIndex")]
        public long LockedEventIndex { get; set; }

        [JsonProperty("myTeam")]
        public List<MyTeam> MyTeam { get; set; }

        [JsonProperty("rerollsRemaining")]
        public long RerollsRemaining { get; set; }

        [JsonProperty("skipChampionSelect")]
        public bool SkipChampionSelect { get; set; }

        [JsonProperty("theirTeam")]
        public List<object> TheirTeam { get; set; }

        [JsonProperty("timer")]
        public Timer Timer { get; set; }

        [JsonProperty("trades")]
        public List<object> Trades { get; set; }
    }

    public partial class Action
    {
        [JsonProperty("actorCellId")]
        public long ActorCellId { get; set; }

        [JsonProperty("championId")]
        public long ChampionId { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("isAllyAction")]
        public bool IsAllyAction { get; set; }

        [JsonProperty("isInProgress")]
        public bool IsInProgress { get; set; }

        [JsonProperty("pickTurn")]
        public long PickTurn { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Bans
    {
        [JsonProperty("myTeamBans")]
        public List<object> MyTeamBans { get; set; }

        [JsonProperty("numBans")]
        public long NumBans { get; set; }

        [JsonProperty("theirTeamBans")]
        public List<object> TheirTeamBans { get; set; }
    }

    public partial class ChatDetails
    {
        [JsonProperty("chatRoomName")]
        public string ChatRoomName { get; set; }

        [JsonProperty("chatRoomPassword")]
        public string ChatRoomPassword { get; set; }
    }

    public partial class EntitledFeatureState
    {
        [JsonProperty("additionalRerolls")]
        public long AdditionalRerolls { get; set; }

        [JsonProperty("unlockedSkinIds")]
        public List<object> UnlockedSkinIds { get; set; }
    }

    public partial class MyTeam
    {
        [JsonProperty("assignedPosition")]
        public string AssignedPosition { get; set; }

        [JsonProperty("cellId")]
        public long CellId { get; set; }

        [JsonProperty("championId")]
        public long ChampionId { get; set; }

        [JsonProperty("championPickIntent")]
        public long ChampionPickIntent { get; set; }

        [JsonProperty("entitledFeatureType")]
        public string EntitledFeatureType { get; set; }

        [JsonProperty("selectedSkinId")]
        public long SelectedSkinId { get; set; }

        [JsonProperty("spell1Id")]
        public long Spell1Id { get; set; }

        [JsonProperty("spell2Id")]
        public long Spell2Id { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("team")]
        public long Team { get; set; }

        [JsonProperty("wardSkinId")]
        public long WardSkinId { get; set; }
    }

    public partial class Timer
    {
        [JsonProperty("adjustedTimeLeftInPhase")]
        public long AdjustedTimeLeftInPhase { get; set; }

        [JsonProperty("internalNowInEpochMs")]
        public long InternalNowInEpochMs { get; set; }

        [JsonProperty("isInfinite")]
        public bool IsInfinite { get; set; }

        [JsonProperty("phase")]
        public string Phase { get; set; }

        [JsonProperty("totalTimeInPhase")]
        public long TotalTimeInPhase { get; set; }
    }
}
