using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class Faceoff : Action
    {
        public Faceoff(Game game, StreamWriter outputWriter) : base(game, outputWriter)
        {

        }
        public override string EndingLog()
        {
            throw new NotImplementedException();
        }

        public override GamePlayer GetDefense(Random random)
        {
            return Game.Away.Centre;
        }

        public override Action GetNextAction(Random random, bool result)
        {
            //after a faceoff the options are
            //carry or pass

            if (GetRandomResult(random))
            {
                return new Pass(Game, OutputStream);
            }
            else
            {
                return new Carry(game, OutputStream);
            }
        }

        public override GamePlayer GetOffense(Random random)
        {
            return Game.Home.Centre;
        }

        public override void PreProcess(Random random)
        {
            throw new NotImplementedException();
        }

        public override void ProcessResult(bool result)
        {
            throw new NotImplementedException();
        }

        public override void ProcessStat(bool result, GamePlayer offense, GamePlayer defense)
        {
            throw new NotImplementedException();
        }

        public override string StartingLog()
        {
            throw new NotImplementedException();
        }
    }
}
