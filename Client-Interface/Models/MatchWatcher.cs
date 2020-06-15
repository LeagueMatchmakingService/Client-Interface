using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using ServerAppDemo.Integration;
using ServerAppDemo.Models.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerAppDemo.Models
{
    public class MatchWatcher
    {
        HttpClient http;
        public bool IsInGame;
        public ILeagueClient lc;
        private static string RedChamp;
        private static string BlueChamp;
        public async Task<Tuple<bool, int>> WatchMatch(Match match)
        {
            RedChamp = "";
            BlueChamp = "";
            IsInGame = true;
            lc = await LeagueClient.Connect();
            var summoner = await lc.GetSummonersModule().GetCurrentSummoner();

            var result = await MatchParser(match, summoner);
            var elo = await SaveMatchResult(result, match, summoner);
            return new Tuple<bool, int>(result, elo);
        }

        private async Task<int> SaveMatchResult(bool result, Match match, SummonerProfile summoner)
        {
            GameOutcome outcome;
            if (match.BluePlayer.SummonerId == summoner.SummonerId)
            {
                if (result)
                {
                    outcome = GameOutcome.BluePlayer;
                }
                else
                {
                    outcome = GameOutcome.RedPlayer;
                }
            }
            else
            {
                if (result)
                {
                    outcome = GameOutcome.RedPlayer;
                }
                else
                {
                    outcome = GameOutcome.BluePlayer;
                }
            }
            var uri = API.EloConnection.SaveMatch;
            var http = new HttpClient();
            var matchOutcome = new MatchResult
            {
                MatchId = match.MatchId,
                BluePlayer = match.BluePlayer.SummonerId,
                RedPlayer = match.RedPlayer.SummonerId,
                Winner = outcome,
                RequestUser = summoner.SummonerId,
                RedChamp = RedChamp,
                BlueChamp = BlueChamp
            };
            var content = new StringContent(JsonConvert.SerializeObject(matchOutcome), Encoding.UTF8, "application/json");
            var response = await http.PostAsync(uri, content);
            var newElo = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
            return newElo;
        }

        private async Task<bool> MatchParser(Match match, SummonerProfile summoner)
        {
          
            while (IsInGame)
            {
                using (var httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                    {
                        if (sslPolicyErrors == SslPolicyErrors.None)
                        {
                            return true;   //Is valid
                        }
                        return true;
                    };
                    http = new HttpClient(httpClientHandler);
                    try
                    {
                        var gamedata = await http.GetStringAsync("https://localhost:2999/liveclientdata/allgamedata");
                        var jsonmodel = JsonConvert.DeserializeObject<MatchOneVOneModel>(gamedata);

                        if(string.IsNullOrWhiteSpace(RedChamp) || string.IsNullOrWhiteSpace(BlueChamp))
                        {
                            var currentPlayer = jsonmodel.AllPlayers.FirstOrDefault(x => x.SummonerName == summoner.DisplayName);
                            var opponent = jsonmodel.AllPlayers.FirstOrDefault(x => x.SummonerName != summoner.DisplayName);
                            if(match.BluePlayer.SummonerId == summoner.SummonerId)
                            {
                                BlueChamp = currentPlayer.ChampionName;
                                RedChamp = opponent.ChampionName;
                            }
                            else
                            {
                                RedChamp = currentPlayer.ChampionName;
                                BlueChamp = opponent.ChampionName;
                            }
                        }

                        foreach (var item in jsonmodel.Events.EventsEvents)
                        {
                            if (item.EventName == "FirstBlood")
                            {
                                IsInGame = false;
                                KillLeague();
                                if (summoner.DisplayName == item.Recipient)
                                    return true;
                                else
                                    return false;
                            }
                            else if (item.EventName == "FirstBrick")
                            {
                                IsInGame = false;
                                KillLeague();
                                if (item.KillerName == summoner.DisplayName ||
                                    (item.KillerName.Contains("T100") && match.BluePlayer.SummonerId == summoner.SummonerId) ||
                                    (item.KillerName.Contains("T200") && match.RedPlayer.SummonerId == summoner.SummonerId))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        foreach (var item in jsonmodel.AllPlayers)
                        {
                            if (item.Scores.CreepScore == 100)
                            {
                                IsInGame = false;
                                KillLeague();
                                if (summoner.DisplayName == item.SummonerName)
                                    return true;
                                else
                                    return false;
                            }
                        }
                    }
                    catch
                    {
                        Thread.Sleep(8000);
                    }
                    Thread.Sleep(2000);
                }
            }
            return false;
        }
        public void KillLeague()
        {
            Process[] procs = null;

            try
            {
                procs = Process.GetProcessesByName("League of Legends");

                Process Proc = procs[0];

                if (!Proc.HasExited)
                {
                    Proc.CloseMainWindow();
                }
            }
            finally
            {
                if (procs != null)
                {
                    foreach (Process p in procs)
                    {
                        p.Dispose();
                    }
                }
            }
        }
    }
    public partial class MatchOneVOneModel
    {
        [JsonProperty("activePlayer")]
        public ActivePlayer ActivePlayer { get; set; }

        [JsonProperty("allPlayers")]
        public List<AllPlayer> AllPlayers { get; set; }

        [JsonProperty("events")]
        public Events Events { get; set; }

        [JsonProperty("gameData")]
        public GameData GameData { get; set; }
    }
    public partial class ActivePlayer
    {
        [JsonProperty("abilities")]
        public Abilities Abilities { get; set; }

        [JsonProperty("championStats")]
        public ChampionStats ChampionStats { get; set; }

        [JsonProperty("currentGold")]
        public double CurrentGold { get; set; }

        [JsonProperty("fullRunes")]
        public FullRunes FullRunes { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
    }
    public partial class Abilities
    {
        [JsonProperty("E")]
        public E E { get; set; }

        [JsonProperty("Passive")]
        public E Passive { get; set; }

        [JsonProperty("Q")]
        public E Q { get; set; }

        [JsonProperty("R")]
        public E R { get; set; }

        [JsonProperty("W")]
        public E W { get; set; }
    }
    public partial class E
    {
        [JsonProperty("abilityLevel", NullValueHandling = NullValueHandling.Ignore)]
        public long? AbilityLevel { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }

        [JsonProperty("rawDisplayName")]
        public string RawDisplayName { get; set; }
    }
    public partial class ChampionStats
    {
        [JsonProperty("abilityPower")]
        public long AbilityPower { get; set; }

        [JsonProperty("armor")]
        public double Armor { get; set; }

        [JsonProperty("armorPenetrationFlat")]
        public long ArmorPenetrationFlat { get; set; }

        [JsonProperty("armorPenetrationPercent")]
        public long ArmorPenetrationPercent { get; set; }

        [JsonProperty("attackDamage")]
        public double AttackDamage { get; set; }

        [JsonProperty("attackRange")]
        public long AttackRange { get; set; }

        [JsonProperty("attackSpeed")]
        public double AttackSpeed { get; set; }

        [JsonProperty("bonusArmorPenetrationPercent")]
        public long BonusArmorPenetrationPercent { get; set; }

        [JsonProperty("bonusMagicPenetrationPercent")]
        public long BonusMagicPenetrationPercent { get; set; }

        [JsonProperty("cooldownReduction")]
        public long CooldownReduction { get; set; }

        [JsonProperty("critChance")]
        public long CritChance { get; set; }

        [JsonProperty("critDamage")]
        public long CritDamage { get; set; }

        [JsonProperty("currentHealth")]
        public double CurrentHealth { get; set; }

        [JsonProperty("healthRegenRate")]
        public double HealthRegenRate { get; set; }

        [JsonProperty("lifeSteal")]
        public long LifeSteal { get; set; }

        [JsonProperty("magicLethality")]
        public long MagicLethality { get; set; }

        [JsonProperty("magicPenetrationFlat")]
        public long MagicPenetrationFlat { get; set; }

        [JsonProperty("magicPenetrationPercent")]
        public long MagicPenetrationPercent { get; set; }

        [JsonProperty("magicResist")]
        public double MagicResist { get; set; }

        [JsonProperty("maxHealth")]
        public double MaxHealth { get; set; }

        [JsonProperty("moveSpeed")]
        public double MoveSpeed { get; set; }

        [JsonProperty("physicalLethality")]
        public long PhysicalLethality { get; set; }

        [JsonProperty("resourceMax")]
        public double ResourceMax { get; set; }

        [JsonProperty("resourceRegenRate")]
        public double ResourceRegenRate { get; set; }

        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("resourceValue")]
        public double ResourceValue { get; set; }

        [JsonProperty("spellVamp")]
        public long SpellVamp { get; set; }

        [JsonProperty("tenacity")]
        public long Tenacity { get; set; }
    }
    public partial class FullRunes
    {
        [JsonProperty("generalRunes")]
        public List<Keystone> GeneralRunes { get; set; }

        [JsonProperty("keystone")]
        public Keystone Keystone { get; set; }

        [JsonProperty("primaryRuneTree")]
        public Keystone PrimaryRuneTree { get; set; }

        [JsonProperty("secondaryRuneTree")]
        public Keystone SecondaryRuneTree { get; set; }

        [JsonProperty("statRunes")]
        public List<StatRune> StatRunes { get; set; }
    }
    public partial class Keystone
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }

        [JsonProperty("rawDisplayName")]
        public string RawDisplayName { get; set; }
    }
    public partial class StatRune
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }
    }
    public partial class AllPlayer
    {
        [JsonProperty("championName")]
        public string ChampionName { get; set; }

        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        [JsonProperty("isDead")]
        public bool IsDead { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("rawChampionName")]
        public string RawChampionName { get; set; }

        [JsonProperty("rawSkinName")]
        public string RawSkinName { get; set; }

        [JsonProperty("respawnTimer")]
        public long RespawnTimer { get; set; }

        [JsonProperty("runes")]
        public Runes Runes { get; set; }

        [JsonProperty("scores")]
        public Scores Scores { get; set; }

        [JsonProperty("skinID")]
        public long SkinId { get; set; }

        [JsonProperty("skinName")]
        public string SkinName { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("summonerSpells")]
        public SummonerSpells SummonerSpells { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }
    }
    public partial class Item
    {
        [JsonProperty("canUse")]
        public bool CanUse { get; set; }

        [JsonProperty("consumable")]
        public bool Consumable { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("itemID")]
        public long ItemId { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }

        [JsonProperty("rawDisplayName")]
        public string RawDisplayName { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }
    }
    public partial class Runes
    {
        [JsonProperty("keystone")]
        public Keystone Keystone { get; set; }

        [JsonProperty("primaryRuneTree")]
        public Keystone PrimaryRuneTree { get; set; }

        [JsonProperty("secondaryRuneTree")]
        public Keystone SecondaryRuneTree { get; set; }
    }
    public partial class Scores
    {
        [JsonProperty("assists")]
        public long Assists { get; set; }

        [JsonProperty("creepScore")]
        public long CreepScore { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("kills")]
        public long Kills { get; set; }

        [JsonProperty("wardScore")]
        public long WardScore { get; set; }
    }
    public partial class SummonerSpells
    {
        [JsonProperty("summonerSpellOne")]
        public E SummonerSpellOne { get; set; }

        [JsonProperty("summonerSpellTwo")]
        public E SummonerSpellTwo { get; set; }
    }
    public partial class Events
    {
        [JsonProperty("Events")]
        public List<Event> EventsEvents { get; set; }
    }
    public partial class Event
    {
        [JsonProperty("EventID")]
        public long EventId { get; set; }

        [JsonProperty("EventName")]
        public string EventName { get; set; }

        [JsonProperty("EventTime")]
        public double EventTime { get; set; }

        [JsonProperty("Assisters", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Assisters { get; set; }

        [JsonProperty("KillerName", NullValueHandling = NullValueHandling.Ignore)]
        public string KillerName { get; set; }

        [JsonProperty("VictimName", NullValueHandling = NullValueHandling.Ignore)]
        public string VictimName { get; set; }

        [JsonProperty("Recipient", NullValueHandling = NullValueHandling.Ignore)]
        public string Recipient { get; set; }

        [JsonProperty("TurretKilled", NullValueHandling = NullValueHandling.Ignore)]
        public string TurretKilled { get; set; }
    }
    public partial class GameData
    {
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("gameTime")]
        public double GameTime { get; set; }

        [JsonProperty("mapName")]
        public string MapName { get; set; }

        [JsonProperty("mapNumber")]
        public long MapNumber { get; set; }

        [JsonProperty("mapTerrain")]
        public string MapTerrain { get; set; }
    }
}