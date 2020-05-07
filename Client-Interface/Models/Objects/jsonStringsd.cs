using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.Models.Objects
{
    public class ApiObject
    {
        public CreateCustomLobby createCustomGameFiveOnFive(string name)
        {
            var cs = new CreateCustomLobby();
            cs.CustomGameLobby = new CustomGameLobby();
            var customGameLobby = cs.CustomGameLobby;
            customGameLobby.Configuration = new Configuration();
            customGameLobby.Configuration.GameTypeConfig = new GameTypeConfig();
            customGameLobby.Configuration.Mutators = new GameTypeConfig();

            customGameLobby.Configuration.GameMode = "CLASSIC";
            customGameLobby.Configuration.GameMutator = "";
            customGameLobby.Configuration.GameServerRegion = "WEST";
            customGameLobby.Configuration.GameTypeConfig.AdvancedLearningQuests = false;
            customGameLobby.Configuration.GameTypeConfig.AllowTrades = true;
            customGameLobby.Configuration.GameTypeConfig.BanMode = "TournamentBanStrategy";
            customGameLobby.Configuration.GameTypeConfig.BanTimerDuration = 30;
            customGameLobby.Configuration.GameTypeConfig.CrossTeamChampionPool = false;
            customGameLobby.Configuration.GameTypeConfig.DeathMatch = false;
            customGameLobby.Configuration.GameTypeConfig.DoNotRemove = false;
            customGameLobby.Configuration.GameTypeConfig.Id = 6;
            customGameLobby.Configuration.GameTypeConfig.LearningQuests = false;
            customGameLobby.Configuration.GameTypeConfig.Name = "GAME_CFG_DRAFT_TOURNAMENT";
            customGameLobby.Configuration.GameTypeConfig.PickMode = "TournamentPickStrategy";
            customGameLobby.Configuration.GameTypeConfig.Reroll = false;
            customGameLobby.Configuration.GameTypeConfig.TeamChampionPool = false;
            customGameLobby.Configuration.MapId = 11;
            customGameLobby.Configuration.MaxPlayerCount = 5;
            customGameLobby.Configuration.Mutators.AdvancedLearningQuests = false;
            customGameLobby.Configuration.Mutators.AllowTrades = true;
            customGameLobby.Configuration.Mutators.BanMode = "TournamentBanStrategy";
            customGameLobby.Configuration.Mutators.Id = 2;
            customGameLobby.Configuration.Mutators.Name = "GAME_CFG_DRAFT_TOURNAMENT";
            customGameLobby.Configuration.Mutators.PickMode = "GAME_CFG_PICK_BLIND";
            customGameLobby.Configuration.Mutators.TeamChampionPool = false;
            customGameLobby.Configuration.SpectatorPolicy = "NotAllowed";
            customGameLobby.Configuration.TeamSize = 5;
            customGameLobby.Configuration.TournamentGameMode = "CLASSIC";
            customGameLobby.Configuration.TournamentPassbackDataPacket = "string";
            customGameLobby.Configuration.TournamentPassbackUrl = "string";
            customGameLobby.GameId = 2;
            customGameLobby.LobbyName = name;
            customGameLobby.LobbyPassword = "1234";
            cs.IsCustom = true;
            cs.QueueId = -1;

            return cs;
        }

        public CreateCustomLobby createCustomGameOneOnOne(string name)
        {
            var cs = new CreateCustomLobby();
            cs.CustomGameLobby = new CustomGameLobby();
            var customGameLobby = cs.CustomGameLobby;
            customGameLobby.Configuration = new Configuration();
            customGameLobby.Configuration.GameTypeConfig = new GameTypeConfig();
            customGameLobby.Configuration.Mutators = new GameTypeConfig();

            customGameLobby.Configuration.GameMode = "ARAM";
            customGameLobby.Configuration.GameMutator = "";
            customGameLobby.Configuration.GameServerRegion = "WEST";
            customGameLobby.Configuration.GameTypeConfig.AdvancedLearningQuests = false;
            customGameLobby.Configuration.GameTypeConfig.AllowTrades = true;
            customGameLobby.Configuration.GameTypeConfig.BanMode = "TournamentBanStrategy";
            customGameLobby.Configuration.GameTypeConfig.BanTimerDuration = 30;
            customGameLobby.Configuration.GameTypeConfig.CrossTeamChampionPool = false;
            customGameLobby.Configuration.GameTypeConfig.DeathMatch = false;
            customGameLobby.Configuration.GameTypeConfig.DoNotRemove = false;
            customGameLobby.Configuration.GameTypeConfig.Id = 1;
            customGameLobby.Configuration.GameTypeConfig.LearningQuests = false;
            customGameLobby.Configuration.GameTypeConfig.Name = "GAME_CFG_DRAFT_TOURNAMENT";
            customGameLobby.Configuration.GameTypeConfig.PickMode = "TournamentPickStrategy";
            customGameLobby.Configuration.GameTypeConfig.Reroll = false;
            customGameLobby.Configuration.GameTypeConfig.TeamChampionPool = false;
            customGameLobby.Configuration.MapId = 12;
            customGameLobby.Configuration.MaxPlayerCount = 2;
            customGameLobby.Configuration.Mutators.AdvancedLearningQuests = false;
            customGameLobby.Configuration.Mutators.AllowTrades = true;
            customGameLobby.Configuration.Mutators.BanMode = "TournamentBanStrategy";
            customGameLobby.Configuration.Mutators.Id = 2;
            customGameLobby.Configuration.Mutators.Name = "GAME_CFG_DRAFT_TOURNAMENT";
            customGameLobby.Configuration.Mutators.PickMode = "GAME_CFG_PICK_BLIND";
            customGameLobby.Configuration.Mutators.TeamChampionPool = false;
            customGameLobby.Configuration.SpectatorPolicy = "NotAllowed";
            customGameLobby.Configuration.TeamSize = 1;
            customGameLobby.Configuration.TournamentGameMode = "ARAM";
            customGameLobby.Configuration.TournamentPassbackDataPacket = "string";
            customGameLobby.Configuration.TournamentPassbackUrl = "string";
            customGameLobby.GameId = 2;
            customGameLobby.LobbyName = name;
            customGameLobby.LobbyPassword = "1234";
            cs.IsCustom = true;
            cs.QueueId = -1;

            return cs;
        }
    }

    public partial class CreateCustomLobby
    {
        [JsonProperty("customGameLobby")]
        public CustomGameLobby CustomGameLobby { get; set; }

        [JsonProperty("isCustom")]
        public bool IsCustom { get; set; }

        [JsonProperty("queueId")]
        public long QueueId { get; set; }
    }

    public partial class CustomGameLobby
    {
        [JsonProperty("configuration")]
        public Configuration Configuration { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("lobbyName")]
        public string LobbyName { get; set; }

        [JsonProperty("lobbyPassword")]
        public string LobbyPassword { get; set; }

        [JsonProperty("practiceGameRewardsDisabledReasons")]
        public object[] PracticeGameRewardsDisabledReasons { get; set; }

        [JsonProperty("spectators")]
        public Spectator[] Spectators { get; set; }

        [JsonProperty("teamOne")]
        public object[] TeamOne { get; set; }

        [JsonProperty("teamTwo")]
        public object[] TeamTwo { get; set; }
    }

    public partial class Configuration
    {
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("gameMutator")]
        public string GameMutator { get; set; }

        [JsonProperty("gameServerRegion")]
        public string GameServerRegion { get; set; }

        [JsonProperty("gameTypeConfig")]
        public GameTypeConfig GameTypeConfig { get; set; }

        [JsonProperty("mapId")]
        public long MapId { get; set; }

        [JsonProperty("maxPlayerCount")]
        public long MaxPlayerCount { get; set; }

        [JsonProperty("mutators")]
        public GameTypeConfig Mutators { get; set; }

        [JsonProperty("spectatorPolicy")]
        public string SpectatorPolicy { get; set; }

        [JsonProperty("teamSize")]
        public long TeamSize { get; set; }

        [JsonProperty("tournamentGameMode")]
        public string TournamentGameMode { get; set; }

        [JsonProperty("tournamentPassbackDataPacket")]
        public string TournamentPassbackDataPacket { get; set; }

        [JsonProperty("tournamentPassbackUrl")]
        public string TournamentPassbackUrl { get; set; }
    }

    public partial class GameTypeConfig
    {
        [JsonProperty("advancedLearningQuests")]
        public bool AdvancedLearningQuests { get; set; }

        [JsonProperty("allowTrades")]
        public bool AllowTrades { get; set; }

        [JsonProperty("banMode")]
        public string BanMode { get; set; }

        [JsonProperty("banTimerDuration")]
        public long BanTimerDuration { get; set; }

        [JsonProperty("battleBoost")]
        public bool BattleBoost { get; set; }

        [JsonProperty("crossTeamChampionPool")]
        public bool CrossTeamChampionPool { get; set; }

        [JsonProperty("deathMatch")]
        public bool DeathMatch { get; set; }

        [JsonProperty("doNotRemove")]
        public bool DoNotRemove { get; set; }

        [JsonProperty("duplicatePick")]
        public bool DuplicatePick { get; set; }

        [JsonProperty("exclusivePick")]
        public bool ExclusivePick { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("learningQuests")]
        public bool LearningQuests { get; set; }

        [JsonProperty("mainPickTimerDuration")]
        public long MainPickTimerDuration { get; set; }

        [JsonProperty("maxAllowableBans")]
        public long MaxAllowableBans { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("onboardCoopBeginner")]
        public bool OnboardCoopBeginner { get; set; }

        [JsonProperty("pickMode")]
        public string PickMode { get; set; }

        [JsonProperty("postPickTimerDuration")]
        public long PostPickTimerDuration { get; set; }

        [JsonProperty("reroll")]
        public bool Reroll { get; set; }

        [JsonProperty("teamChampionPool")]
        public bool TeamChampionPool { get; set; }
    }

    public partial class Spectator
    {
        [JsonProperty("autoFillEligible")]
        public bool AutoFillEligible { get; set; }

        [JsonProperty("autoFillProtectedForPromos")]
        public bool AutoFillProtectedForPromos { get; set; }

        [JsonProperty("autoFillProtectedForSoloing")]
        public bool AutoFillProtectedForSoloing { get; set; }

        [JsonProperty("autoFillProtectedForStreaking")]
        public bool AutoFillProtectedForStreaking { get; set; }

        [JsonProperty("botChampionId")]
        public long BotChampionId { get; set; }

        [JsonProperty("botDifficulty")]
        public string BotDifficulty { get; set; }

        [JsonProperty("canInviteOthers")]
        public bool CanInviteOthers { get; set; }

        [JsonProperty("excludedPositionPreference")]
        public string ExcludedPositionPreference { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        [JsonProperty("isOwner")]
        public bool IsOwner { get; set; }

        [JsonProperty("isSpectator")]
        public bool IsSpectator { get; set; }

        [JsonProperty("positionPreferences")]
        public PositionPreferences PositionPreferences { get; set; }

        [JsonProperty("showPositionExcluder")]
        public bool ShowPositionExcluder { get; set; }

        [JsonProperty("summonerInternalName")]
        public string SummonerInternalName { get; set; }
    }

    public partial class PositionPreferences
    {
        [JsonProperty("firstPreference")]
        public string FirstPreference { get; set; }

        [JsonProperty("secondPreference")]
        public string SecondPreference { get; set; }
    }

    public partial class LobbyInvitation
    {
        [JsonProperty("invitationId")]
        public string InvitationId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("toSummonerId")]
        public long ToSummonerId { get; set; }

        [JsonProperty("toSummonerName")]
        public string ToSummonerName { get; set; }

    }

    public partial class StartGame
    {
        [JsonProperty("failedPlayers")]
        public FailedPlayer[] FailedPlayers { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public partial class FailedPlayer
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
    }

    public partial class LobbyPlayerInfo
    {
        [JsonProperty("allowedChangeActivity")]
        public bool AllowedChangeActivity { get; set; }

        [JsonProperty("allowedInviteOthers")]
        public bool AllowedInviteOthers { get; set; }

        [JsonProperty("allowedKickOthers")]
        public bool AllowedKickOthers { get; set; }

        [JsonProperty("allowedStartActivity")]
        public bool AllowedStartActivity { get; set; }

        [JsonProperty("allowedToggleInvite")]
        public bool AllowedToggleInvite { get; set; }

        [JsonProperty("autoFillEligible")]
        public bool AutoFillEligible { get; set; }

        [JsonProperty("autoFillProtectedForPromos")]
        public bool AutoFillProtectedForPromos { get; set; }

        [JsonProperty("autoFillProtectedForSoloing")]
        public bool AutoFillProtectedForSoloing { get; set; }

        [JsonProperty("autoFillProtectedForStreaking")]
        public bool AutoFillProtectedForStreaking { get; set; }

        [JsonProperty("botChampionId")]
        public long BotChampionId { get; set; }

        [JsonProperty("botDifficulty")]
        public string BotDifficulty { get; set; }

        [JsonProperty("botId")]
        public string BotId { get; set; }

        [JsonProperty("firstPositionPreference")]
        public string FirstPositionPreference { get; set; }

        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        [JsonProperty("isLeader")]
        public bool IsLeader { get; set; }

        [JsonProperty("isSpectator")]
        public bool IsSpectator { get; set; }

        [JsonProperty("lastSeasonHighestRank")]
        public string LastSeasonHighestRank { get; set; }

        [JsonProperty("puuid")]
        public Guid Puuid { get; set; }

        [JsonProperty("ready")]
        public bool Ready { get; set; }

        [JsonProperty("secondPositionPreference")]
        public string SecondPositionPreference { get; set; }

        [JsonProperty("showGhostedBanner")]
        public bool ShowGhostedBanner { get; set; }

        [JsonProperty("summonerIconId")]
        public long SummonerIconId { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("summonerInternalName")]
        public string SummonerInternalName { get; set; }

        [JsonProperty("summonerLevel")]
        public long SummonerLevel { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }
    }

    public partial class InviteModel
    {
        [JsonProperty("canAcceptInvitation")]
        public bool CanAcceptInvitation { get; set; }

        [JsonProperty("fromSummonerId")]
        public long FromSummonerId { get; set; }

        [JsonProperty("fromSummonerName")]
        public string FromSummonerName { get; set; }

        [JsonProperty("gameConfig")]
        public GameConfig GameConfig { get; set; }

        [JsonProperty("invitationId")]
        public string InvitationId { get; set; }

        [JsonProperty("restrictions")]
        public object[] Restrictions { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }

    public partial class GameConfig
    {
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("inviteGameType")]
        public string InviteGameType { get; set; }

        [JsonProperty("mapId")]
        public long MapId { get; set; }

        [JsonProperty("queueId")]
        public long QueueId { get; set; }
    }
}
