using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public class GameTeamStats
    {
        public Game Game { get; set; }
        public Team Team { get; set; }
        public GameTeamType Status { get; set; }
        public int[] Goals { get; set; }
        public GameResult Result { get; set; }
    }

}
