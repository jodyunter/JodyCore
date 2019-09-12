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

        public Position CurrentPosition { get; set; }
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
                case ActionType.ForeCheck:
                    return Player.ForeCheckSkill;
                case ActionType.Carry:
                    return Player.CarrySkill;
                case ActionType.Scramble:
                    return Player.ForeCheckSkill; //change this to a combination of stuff?
                case ActionType.Shoot:
                    return Player.ShootingSkill;
                case ActionType.Block:
                    return Player.BlockingSkill;
                case ActionType.Score:
                    return Player.ScoringSkill;
                case ActionType.Save:
                    return Player.SavingSkill;
                case ActionType.Freeze:
                    return Player.FreezingSkill;
                default:
                    throw new Exception("No Action Type for " + actionType);
            }
        }

        public void ChangeValueForActionType(ActionType actionType, bool isWin, int value)
        {
            switch (actionType)
            {
                case ActionType.FaceOff:
                    ChangeValue(isWin, Stats.FaceOffWins, Stats.FaceOffLoses, value);
                    break;
                case ActionType.Pass:
                    ChangeValue(isWin, Stats.PassesMade, Stats.PassesIntercepted, value); break;
                case ActionType.Intercept:
                    ChangeValue(isWin, Stats.Interceptions, Stats.InterceptionsMissed, value);
                    break;
                case ActionType.ForeCheck:
                    ChangeValue(isWin, Stats.ForeChecksMade, Stats.ForeChecksFailed, value);
                    break;
                case ActionType.Carry:
                    ChangeValue(isWin, Stats.CarriesMade, Stats.CarriesFailed, value);
                    break;
                case ActionType.Scramble:
                    ChangeValue(isWin, Stats.ScramblesWon, Stats.ScramblesLost, value);
                    break;
                case ActionType.Freeze:
                    ChangeValue(isWin, Stats.Freezes, Stats.FreezesFailed, value);
                    break;
                case ActionType.Save:
                    ChangeValue(isWin, Stats.SavesMade, Stats.GoalsAllowed, value);
                    break;
                case ActionType.Score:
                    ChangeValue(isWin, Stats.GoalsScored, Stats.ShotsSaved, value);
                    break;
                case ActionType.Shoot:
                    ChangeValue(isWin, Stats.ShotsOnGoal, Stats.ShotsBlocked, value);
                    break;
                case ActionType.Block:
                    ChangeValue(isWin, Stats.BlockedShots, Stats.BlocksMissed, value);
                    break;
                default:
                    throw new Exception("No Action Type for " + actionType);
            }
        }

        public void ChangeValue(bool isWin, int winnerValue, int loserValue, int value)
        {
            if (isWin) winnerValue += value;
            else loserValue += value;
        }
        
    }

}
