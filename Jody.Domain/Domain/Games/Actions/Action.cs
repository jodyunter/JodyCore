﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public abstract class Action
    {        
        public static List<Position> AllPlayingPositionsButGoalie = new List<Position>() { Position.Centre, Position.LeftWing, Position.RightWing, Position.LeftDefense, Position.RightDefense };
        public Game Game { get; set; }
        public StreamWriter OutputStream { get; set; }
        public GamePlayer Winner { get; set; }
        public GamePlayer Loser { get; set; }
        public GamePlayer Offense { get; set; }
        public GamePlayer Defense { get; set; }
        public abstract ActionType OffenseActionType { get; }
        public abstract ActionType DefenseActionType { get; }
        public abstract int GetWinnerTimeOut { get; }
        public abstract int GetLoserTimeOut { get; }
        public abstract int GetGameTimeSpent { get; }

        public bool Result { get; set; }
        public Action(Game game, StreamWriter outputStream)
        {
            Game = game;
            OutputStream = outputStream;
        }
        public void Process(Random random)
        {
            PreProcess(random);      
            
            Result = GetResult(random);            

            ProcessResult(random);
            ProcessStat(Offense, Defense);

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

        public virtual void PreProcessForAction(Random random)
        {
            //by default do nothing
        }
        public void ProcessStat(GamePlayer offense, GamePlayer defense)
        {
            offense.ChangeValueForActionType(OffenseActionType, Result, 1);
            defense.ChangeValueForActionType(DefenseActionType, !Result, 1);
        }
        public abstract void SetOffense(Random random);
        public abstract void SetDefense(Random random);
        public bool DoesOffenseWin(Random random)
        {
            var defenseValue = Defense == null ? 0: Defense.GetSkillForActionType(DefenseActionType);
            var offenseValue = Offense == null ? 0 : Offense.GetSkillForActionType(OffenseActionType);

            return GetRandomResult(random, Offense.GetSkillForActionType(OffenseActionType), defenseValue);
        }

        public int GetRandomValueFromRange(Random random, int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public bool GetRandomResult(Random random, int offenseValue, int defenseValue)
        {
            return random.Next(offenseValue) >= random.Next(defenseValue);
        }
        public bool GetResult(Random random)
        {
            var result = DoesOffenseWin(random);

            if (result)
            {
                Winner = Offense;
                Loser = Defense;
            }
            else
            {
                Winner = Defense;
                Loser = Offense;
            }

            return result;
        }
        public void ProcessResult(Random random)
        {
            //increment time on players
            if (Winner != null) Winner.TimeUntilAvailable += GetWinnerTimeOut;
            if (Loser != null) Loser.TimeUntilAvailable += GetLoserTimeOut;

            //increment game time
            Game.CurrentTime += GetGameTimeSpent;

            ProcessResultsForAction(random);

        }

        public abstract void ProcessResultsForAction(Random random);

        public abstract Action GetNextAction(Random random);
        public abstract string GetLogMessage();
        
        public void Log(string outputString)
        {
            OutputStream.WriteLine(outputString);
        }        
    }
}
