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

        public override ActionType OffenseActionType { get { return ActionType.Scramble; } }

        public override ActionType DefenseActionType { get { return ActionType.Scramble; } }

        public override int GetWinnerTimeOut { get { return 0; } }

        public override int GetLoserTimeOut { get { return 5; } }

        public override int GetGameTimeSpent { get { return 1; } }

        public override string GetLogMessage()
        {
            var output = string.Format("Scramble!");
            output += string.Format("{0} gets to it before {1}", Winner.Player.Name, Game.PuckCarrier.Player.Name);

            return output;

        }

        public override Action GetNextAction(Random random)
        {
            if (Offense == null && Defense == null)
            {
                return new Faceoff(Game, OutputStream);
            }
            else
            {
                var value = GetRandomValueFromRange(random, 0, 2);

                switch(value)
                {
                    case 0:
                        return new Carry(Game, OutputStream);
                    case 1:
                        return new Pass(Game, OutputStream);
                    case 2:
                        return new Shoot(Game, OutputStream);
                    default:
                        throw new Exception("Value: " + value + " could not be processed in GetNextAction in Scramble");
                }
            }            
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
                Game.CarrierPoints += 1;
            }            
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
