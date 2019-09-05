using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public abstract class Action
    {
        
        public Game Game { get; set; }
        public StreamWriter OutputStream { get; set; }
        public GamePlayer Winner { get; set; }
        public GamePlayer Loser { get; set; }
        public GamePlayer Offense { get; set; }
        public GamePlayer Defense { get; set; }
        public abstract ActionType OffenseActionType { get; }
        public abstract ActionType DefenseActionType { get; }
        public abstract int GetWinnerTimeOut { get; set; }
        public abstract int GetLoserTimeOut { get; }
        public abstract int GetGameTimeSpent { get; }
        public Action(Game game, StreamWriter outputStream)
        {
            Game = game;
            OutputStream = outputStream;
        }
        public void Process(Random random)
        {
            PreProcess(random);      
            
            var result = GetResult(random, Offense, Defense);            

            ProcessResult(result);
            ProcessStat(result, Offense, Defense);

            Log(GetLogMessage());  //p1 tries to pass to p2, but p3 intercepts.  p1 passes to p2, p3 misses the interception.
        }
        
        public void PreProcess(Random random)
        {
            //dcrease time on players
            Game.Home.ReduceTimeUntilAvailable();
            Game.Away.ReduceTimeUntilAvailable();
            
            SetOffense(random);
            SetDefense(random);

            PreProcessForAction(random);
        }

        public abstract void PreProcessForAction(Random random);
        public abstract void ProcessStat(bool result, GamePlayer offense, GamePlayer defense);
        public abstract void SetOffense(Random random);
        public abstract void SetDefense(Random random);
        public bool DoesOffenseWin(Random random, GamePlayer offense, GamePlayer defense)
        {
            return GetRandomResult(random, offense.GetSkillForActionType(OffenseActionType), defense.GetSkillForActionType(DefenseActionType));
        }

        public bool GetRandomResult(Random random, int offenseValue, int defenseValue)
        {
            return random.Next(offenseValue) >= random.Next(defenseValue);
        }
        public bool GetResult(Random random, GamePlayer offense, GamePlayer defense)
        {
            var result = DoesOffenseWin(random, offense, defense);

            if (result)
            {
                Winner = offense;
                Loser = defense;
            }
            else
            {
                Winner = defense;
                Loser = offense;
            }

            return result;
        }
        public void ProcessResult(bool result, Random random)
        {
            //increment time on players
            Winner.TimeUntilAvailable += GetWinnerTimeOut;
            Loser.TimeUntilAvailable += GetLoserTimeOut;

            //increment game time
            Game.CurrentTime += GetGameTimeSpent;

            ProcessResultsForAction(result, random;

        }

        public abstract void ProcessResultsForAction(bool result, Random random);

        public abstract Action GetNextAction(Random random, bool result);
        public abstract string GetLogMessage();
        
        public void Log(string outputString)
        {
            OutputStream.WriteLine(outputString);
        }        
    }
}
