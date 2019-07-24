using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public class GamePlayer
    {
        public Game Game { get; set; }
        public Player Player { get; set; }
        public GamePlayerStats Stats { get; set; }                
        public int TimeUntilAvailable { get; set; }

    }

}
