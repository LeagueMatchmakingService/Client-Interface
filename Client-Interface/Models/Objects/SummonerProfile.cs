﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.Models.Objects
{
    public class SummonerProfile
    {
        [JsonProperty("accountId")]
        public long AccountId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("internalName")]
        public string InternalName { get; set; }

        [JsonProperty("lastSeasonHighestRank")]
        public string LastSeasonHighestRank { get; set; }

        [JsonProperty("percentCompleteForNextLevel")]
        public int PercentCompleteForNextLevel { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("rerollPoints")]
        public RerollPointsData RerollPoints { get; set; }

        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("xpSinceLastLevel")]
        public int XpSinceLastLevel { get; set; }

        [JsonProperty("xpUntilNextLevel")]
        public int XpUntilNextLevel { get; set; }

        public class RerollPointsData
        {
            [JsonProperty("currentPoints")]
            public int CurrentPoints { get; set; }

            [JsonProperty("maxRolls")]
            public int MaxRolls { get; set; }

            [JsonProperty("numberOfRolls")]
            public int NumberOfRolls { get; set; }

            [JsonProperty("pointsCostToRoll")]
            public int PointsCostToRoll { get; set; }

            [JsonProperty("pointsToReroll")]
            public int PointsToReroll { get; set; }
        }
    }
}
