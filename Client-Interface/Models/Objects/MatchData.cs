using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.Models.Objects
{
    public class Match
    {
        public Guid MatchId { get; set; }
        public Player RedPlayer { get; set; }
        public Player BluePlayer { get; set; }

    }
    public class Player
    {
        public string ConnectionId { get; set; }
        public string SummonerId { get; set; }
        public int Elo { get; set; }
        public int SearchElo { get; set; }
        public DateTime Created { get; set; }
    }
    public class MatchResult
    {
        public Guid MatchId { get; set; }
        public string BluePlayer { get; set; }
        public string RedPlayer { get; set; }
        public GameOutcome Winner { get; set; }
        public string RequestUser { get; set; }
        public string RedChamp { get; set; }
        public string BlueChamp { get; set; }
    }
    public enum GameOutcome
    {
        BluePlayer = 1,
        RedPlayer = 0
    }
}

