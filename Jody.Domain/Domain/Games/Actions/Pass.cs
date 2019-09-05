using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class Pass:Action
    {
        //passing has a third player involved, will need to override approrpiately
        public Pass(Game game, StreamWriter outputWriter) : base(game, outputWriter)
        {

        }

        public override ActionType OffenseActionType => throw new NotImplementedException();

        public override ActionType DefenseActionType => throw new NotImplementedException();

        public override int GetWinnerTimeOut { get => throw new NotImplementedException();  }

        public override int GetLoserTimeOut => throw new NotImplementedException();

        public override int GetGameTimeSpent => throw new NotImplementedException();

        public override string GetLogMessage()
        {
            throw new NotImplementedException();
        }

        public override Action GetNextAction(Random random)
        {
            throw new NotImplementedException();
        }

        public override void PreProcessForAction(Random random)
        {
            throw new NotImplementedException();
        }

        public override void ProcessResultsForAction(bool result, Random random)
        {
            throw new NotImplementedException();
        }

        public override void ProcessStat(bool result, GamePlayer offense, GamePlayer defense)
        {
            throw new NotImplementedException();
        }

        public override void SetDefense(Random random)
        {
            throw new NotImplementedException();
        }

        public override void SetOffense(Random random)
        {
            throw new NotImplementedException();
        }
    }
}
