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


        //general play is an action is taken, player that loses the action or completes the action is unavailable for a time
        //faceoff -> player 
        //player can carry, pass or shoot
        //player carries and another tries to check
        //player passes and another intercepts
        //player shoots and all remaining players get to try to block, with the best blocker getting first try
        public Action GetNextAction(Action lastAction, int currentPeriod, int currentTime)
        {
            return null;
        }

    }
}
