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
            if (PuckCarrier == null)
            {
                MakeAllPlayersAvailable();
            }
        }

        public bool IsGameComplete()
        {
            return false;
        }
        public bool IsPeriodComplete()
        {
            return false;
        }

        public void RunFaceOff(Random random)
        {
            var centre1 = Home.Centre;
            var centre2 = Away.Centre;

            if (GetResult(random))
            {
                PuckCarrier = centre1;
            }
        }

        public void NextAction(Random random)
        {
            
        }

        public void MakeAllPlayersAvailable()
        {
            Home.MakeAllPlayersAvailable();
            Away.MakeAllPlayersAvailable();
        }

        public bool GetResult(Random random)
        {
            return random.Next(26) >= random.Next(26);
        }

    }
}
