﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.Models.Objects
{
    public class Match
    {
        public string MatchId { get; set; }
        public Player RedPlayer { get; set; }
        public Player BluePlayer { get; set; }

    }
    public class Player
    {
        public string ConnectionId { get; set; }
        public int SummonerId { get; set; }
        public int Elo { get; set; }
        public int SearchElo { get; set; }
        public DateTime Created { get; set; }
    }
}
