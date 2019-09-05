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

        public int GetSkillForActionType(ActionType actionType)
        {
            switch(actionType)
            {
                case ActionType.FaceOff:
                    return Player.FaceOffSkill;
                case ActionType.Pass:
                    return Player.PassingSkill;
                case ActionType.Intercept:
                    return Player.InterceptSkill;
                default:
                    throw new Exception("No Action Type for " + actionType);
            }
        }
    }

}
