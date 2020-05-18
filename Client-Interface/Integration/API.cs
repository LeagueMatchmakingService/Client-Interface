using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.Integration
{
    public static class API
    {
        private static string eloUri = "https://elorestapi.azurewebsites.net/api/Elo";


        public static class EloConnection
        {
            public static string SaveMatch => $"{eloUri}/SaveMatch";
        }

        public static class Leaderboard
        {
            public static string GetLeaderboard => $"https://leaderboardhub.azurewebsites.net/leaderboard/50";
        }
    }
}
