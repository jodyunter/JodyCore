using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions.Hockey
{
    public class Carry : HockeyAction
    {
        public Carry(Game game, StreamWriter outputWriter) : base(game, outputWriter)
        {

        }

        public override ActionType OffenseActionType { get { return ActionType.Carry; } }

        public override ActionType DefenseActionType { get { return ActionType.ForeCheck; } }

        public override int GetWinnerTimeOut { get { return 0; } }

        public override int GetLoserTimeOut { get { return 3; } } 

        public override int GetGameTimeSpent { get { return 1; } }

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
