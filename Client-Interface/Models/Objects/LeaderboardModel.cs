using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.Models.Objects
{
    public class LeaderboardModel
    {
        public string Name { get; set; }
        public int Elo { get; set; }

        public Regions Region { get; set; }
    }
}
