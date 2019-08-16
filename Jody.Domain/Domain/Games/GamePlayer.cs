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

        public void MakeAvailable()
        {
            TimeUntilAvailable = 0;
        }

        public void ReduceTimeUntilAvailable()
        {
            if (TimeUntilAvailable > 0)
            {
                TimeUntilAvailable--;
            }
        }
    }

}
