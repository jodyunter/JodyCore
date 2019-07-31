using Jody.Domain.Games.Actions;
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
        public Action LastAction { get; set; }

        //game rules, like overtime, total periods, etc
        public void PlayGame(Random random)
        {
            //pick up where we left off
            //get last action and find next action
            //process next action   
            CurrentPeriod = 1;
            CurrentTime = 1;
            LastAction = null;

            while (!IsGameComplete())
            {
                while (!IsPeriodComplete())
                {
                    var action = GetNextAction(random);
                    action.SetupAction(random);
                    action.ProcessAction(random);
                    CurrentTime++;
                }

                CurrentPeriod++;
                CurrentTime = 1;
                LastAction = null;
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

        //general play is an action is taken, player that loses the action or completes the action is unavailable for a time
        //faceoff -> player 
        //player can carry, pass or shoot
        //player carries and another tries to check
        //player passes and another intercepts
        //player shoots and all remaining players get to try to block, with the best blocker getting first try
        public Action GetNextAction(Random random)
        {
            //if game is done do something
            //if period is done do something
            //otherwise process the action
            if (LastAction == null)
            {
                //setup a faceoff
                //this should have a setup or something
                var action = new FaceOffAction(this, CurrentPeriod, CurrentTime);                

                return action;
            }
            else
            {
                return LastAction.GetNextAction(random);
            }
                        
        }

    }
}
