using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public class GameStats
    {
        public Game Game { get; set; }        
        public GameTeamStats HomeStats { get; set; }
        public GameTeamStats AwayStats { get; set; }
    }

}
