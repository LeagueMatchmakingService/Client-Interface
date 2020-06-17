using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.Models.Objects
{
    public partial class Region
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("region")]
        public string RegionRegion { get; set; }

        [JsonProperty("webLanguage")]
        public string WebLanguage { get; set; }

        [JsonProperty("webRegion")]
        public string WebRegion { get; set; }
    }

    public enum Regions
    {
        EUW,
        NA,
        EUNE,
        TR,
        RU,
        KR,
        CN,
        OCE,
        LAS,
        LAN,
        JP
    }
}
