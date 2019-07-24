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
        public void PlayMoment(Random random)
        {
            //pick up where we left off
            //get last action and find next action
            //process next action            
            CurrentTime++;
        }

        public Action GetNextAction(Action lastAction, int currentPeriod, int currentTime)
        {
            if (lastAction == null)
            {
                return new Action()
                {
                    ActionType = ActionType.Faceoff,
                    Winner = null,
                    Loser = null,
                    Period = currentPeriod,
                    Moment = currentTime + 1,
                    Order = lastAction.Order++,
                    PuckCarrier = Home.Centre,
                    Opponent = Away.Centre
                };
            }

            return null;
        }

    }
}
