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

        public void Process()
        {
            var offense = GetOffense();
            var defense = GetDefense();

            Log(StartingLog());

            var result = GetResult(offense, defense);

            ProcessResult(result);
            ProcessStat(result, offense, defense);

            Log(EndingLog());
        }
        public abstract void ProcessStat(bool result, GamePlayer offense, GamePlayer defense);
        public abstract GamePlayer GetOffense();
        public abstract GamePlayer GetDefense();
        public abstract bool DoesOffenseWin(GamePlayer offense, GamePlayer defense);
        public bool GetResult(GamePlayer offense, GamePlayer defense)
        {
            var result = DoesOffenseWin(offense, defense);

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
        public abstract void ProcessResult(bool result);
        public abstract Action GetNextAction(bool result);
        public abstract string StartingLog();
        public abstract string EndingLog();

        public void Log(string outputString)
        {
            OutputStream.WriteLine(outputString);
        }        
    }
}
