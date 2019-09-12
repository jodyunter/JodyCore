using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class Score:HockeyAction
    {
        public Score(Game game, StreamWriter outputWriter) : base(game, outputWriter)
        {

        }

        public override ActionType OffenseActionType => throw new NotImplementedException();

        public override ActionType DefenseActionType => throw new NotImplementedException();

        public override int GetWinnerTimeOut => throw new NotImplementedException();

        public override int GetLoserTimeOut => throw new NotImplementedException();

        public override int GetGameTimeSpent => throw new NotImplementedException();

        public override ActionType ActionType => throw new NotImplementedException();

        public override string GetLogMessage()
        {
            throw new NotImplementedException();
        }

        public override void ProcessResultsForAction(Random random)
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
