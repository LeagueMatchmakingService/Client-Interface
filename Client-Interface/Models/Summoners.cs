using ServerAppDemo.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.Models
{
    public class Summoners
    {
        ILeagueClient League;
        const string endpointRoot = "/lol-summoner/v1/";

        public Summoners(ILeagueClient league)
        {
            League = league;
        }


        public bool IsNameAvailable(string name)
        {
            var result = League.MakeApiRequest(HttpMethod.Get, endpointRoot + "check-name-availability/" + name).Result;
            return bool.Parse(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<SummonerProfile> GetCurrentSummoner()
        {
            var response = await League.MakeApiRequestAs<SummonerProfile>(HttpMethod.Get, endpointRoot + "current-summoner");
            return response;
        }

        public SummonerProfile GetSummonerProfile(string name)
        {
            return League.MakeApiRequestAs<SummonerProfile>(HttpMethod.Get, endpointRoot + "summoners/" + name).Result;
        }
    }
}
