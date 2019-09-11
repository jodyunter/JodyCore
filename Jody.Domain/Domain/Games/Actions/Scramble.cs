using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class Scramble:Action
    {
        public Scramble(Game game, StreamWriter outputWriter) : base(game, outputWriter)
        {

        }

        public override ActionType OffenseActionType => throw new NotImplementedException();

        public override ActionType DefenseActionType => throw new NotImplementedException();

        public override int GetWinnerTimeOut => throw new NotImplementedException();

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

        public override void ProcessResultsForAction(Random random)
        {
            //if the defense team wins, change possession
            //if the offense team wins, continue
            if (!Result)
            {
                Game.ChangePossession();
                Game.PuckCarrier = Defense;
            }
            else
            {
                Game.PuckCarrier = Offense;
            }
            
        }

        public override void ProcessStat(GamePlayer offense, GamePlayer defense)
        {
            throw new NotImplementedException();
        }

        public override void SetDefense(Random random)
        {
            Game.GetDefense().GetPositionFromList(AllPlayingPositionsButGoalie, random);
        }

        public override void SetOffense(Random random)
        {
            Game.GetOffense().GetPositionFromList(AllPlayingPositionsButGoalie, random);
        }
    }
}
