using Newtonsoft.Json;
using ServerAppDemo.Integration;
using ServerAppDemo.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServerAppDemo.Models
{
    public class RetrieveInformation
    {



        public async Task<List<LeaderboardModel>> GetLeaderboard()
        {
            var http = new HttpClient();
            var uri = API.Leaderboard.GetLeaderboard;
            var response = await http.GetAsync(uri);
            var leaderboard = JsonConvert.DeserializeObject<List<LeaderboardModel>>(await response.Content.ReadAsStringAsync());
            return leaderboard;
        }



    }
}
