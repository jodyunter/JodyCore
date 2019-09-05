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

        public Action(Game game, StreamWriter outputStream)
        {
            Game = game;
            OutputStream = outputStream;
        }
        public void Process(Random random)
        {
            PreProcess(random);

            var offense = GetOffense(random);
            var defense = GetDefense(random);

            Log(StartingLog());

            var result = GetResult(random, offense, defense);

            ProcessResult(result);
            ProcessStat(result, offense, defense);

            Log(EndingLog());
        }

        public abstract void PreProcess(Random random);
        public abstract void ProcessStat(bool result, GamePlayer offense, GamePlayer defense);
        public abstract GamePlayer GetOffense(Random random);
        public abstract GamePlayer GetDefense(Random random);
        public bool DoesOffenseWin(Random random, GamePlayer offense, GamePlayer defense)
        {
            return GetRandomResult(random);
        }

        public bool GetRandomResult(Random random)
        {
            return random.Next(26) >= random.Next(26);
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
        public abstract void ProcessResult(bool result);
        public abstract Action GetNextAction(Random random, bool result);
        public abstract string StartingLog();
        public abstract string EndingLog();

        public void Log(string outputString)
        {
            OutputStream.WriteLine(outputString);
        }        
    }
}
