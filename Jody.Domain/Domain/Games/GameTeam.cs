using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public class GameTeam
    {
        public Game Game { get; set; }
        public GameTeamStats Stats { get; set; }
        public IEnumerable<GamePlayer> Roster { get; set; }        

        public GamePlayer Centre { get; set; }
        public GamePlayer LeftWing { get; set; }
        public GamePlayer RightWing { get; set; }
        public GamePlayer RightDefense { get; set; }
        public GamePlayer LeftDefense { get; set; }
        public GamePlayer Goalie { get; set; }
        
    }
}
