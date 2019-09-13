using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class Pass:HockeyAction
    {
        public List<Position> RecieverList { get; set; }
        //passing has a third player involved, will need to override approrpiately
        public Pass(Game game, StreamWriter outputWriter) : base(game, outputWriter)
        {
            //remove the carrier from the list
            RecieverList = new List<Position>() { Position.RightDefense, Position.LeftDefense, Position.RightWing, Position.LeftWing };
            var puckCarrierPosition = game.PuckCarrier.CurrentPosition;

            RecieverList.Remove(puckCarrierPosition);
        }

        public override ActionType OffenseActionType { get { return ActionType.Pass; } }

        public override ActionType DefenseActionType { get { return ActionType.Intercept; } }

        public override int GetWinnerTimeOut { get { return 5; }  }

        public override int GetLoserTimeOut { get { return 5; } }

        public override int GetGameTimeSpent { get { return 1; } }

        public override ActionType ActionType => throw new NotImplementedException();

        public override string GetLogMessage()
        {
            if (Result)
            {
                //pass successful message
                return "Pass successful message";
            }
            else
            {
                //pass intercepted message
                return "Pass Intercepted message";
            }
            
        }

        public override void ProcessResultsForAction(Random random)
        {
            if (!Result)
            {
                Game.ChangePossession();
            }

            //choose player who gets the puck
            var team = Game.GetOffense();
            var receiverPosition = team.GetPositionFromList(RecieverList, random);
            var receiver = team.GetPlayerByPosition(receiverPosition);
            if (Result)
            {

            }
            Game.PuckCarrier = receiver;
            Game.CarrierPoints += 1;
        }

        public override void SetDefense(Random random)
        {
            //get an open winger
            var defendingTeam = Game.GetDefense();
            var defendingPosition = defendingTeam.GetPositionFromList(new List<Position> { Position.LeftWing, Position.RightWing }, random);

            Defense = defendingTeam.GetPlayerByPosition(defendingPosition);
        }

        public override void SetOffense(Random random)
        {
            Offense = Game.PuckCarrier;
        }
    }
}
