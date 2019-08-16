using System;

namespace Jody.Domain.Games
{
    public class Game
    {
        public int Number { get; set; }        
        public GameTeam Home { get; set; }
        public GameTeam Away { get; set; }
        public GamePlayer PuckCarrier { get; set; }
        
        public int CurrentPeriod { get; set; }
        public int CurrentTime { get; set; }
        public GameStatus Status { get; set; }
        public GameStats Stats { get; set; }
        
        //game rules, like overtime, total periods, etc
        public void PlayGame(Random random)
        {
    
        }

        public bool IsGameComplete()
        {
            return false;
        }
        public bool IsPeriodComplete()
        {
            return false;
        }


    }
}
