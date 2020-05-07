using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.wwwroot.Models
{
    public class MatchResult
    {
        public Guid MatchId { get; set; }
        public string RedPlayer { get; set; }
        public string BluePlayer { get; set; }
        public GameOutcome Winner { get; set; }
    }

    public enum GameOutcome
    {
        RedPlayer,
        BluePlayer
    }
}
