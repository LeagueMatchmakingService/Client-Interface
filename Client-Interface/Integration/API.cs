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
            public static string SaveMatch => $"{eloUri}/CalculateMatchOutcomeOneVOne/";
        }


    }
}
