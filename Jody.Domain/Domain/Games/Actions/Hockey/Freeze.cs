using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions.Hockey
{
    public class Freeze : HockeyAction
    {
        public Freeze(Game game, StreamWriter outputStream) :base(game, outputStream)
        {

        }
        public override ActionType OffenseActionType => throw new NotImplementedException();

        public override ActionType DefenseActionType => throw new NotImplementedException();

        public override int GetWinnerTimeOut => throw new NotImplementedException();

        public override int GetLoserTimeOut => throw new NotImplementedException();

        public override int GetGameTimeSpent => throw new NotImplementedException();

        public override ActionType ActionType { get => throw new NotImplementedException(); }

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
