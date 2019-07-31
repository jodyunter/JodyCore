using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class FaceOffAction : Action
    {      

        public FaceOffAction(Game game, int period, int moment)
            :base(ActionType.Faceoff, game, period, moment)
        {
            WinnerPositionPreference = new Position[] { Position.LeftWing, Position.RightWing, Position.LeftDefense, Position.RightDefense };
        }

        public override void SetupAction(Random random)
        {            
            PuckCarrier = Game.Home.Centre;
            Opponent = Game.Away.Centre;
        }

        public override Action GetNextAction(Random random)
        {
            throw new NotImplementedException();
        }

        public override void ProcessAction(Random random)
        {
            //decrement the remaining time for all players

            //determine winner
            Winner = PuckCarrier;
            Loser = Opponent;

            //find the next puck carrier

            //add the timeout for the faceoff person

            //mark as processed

            throw new NotImplementedException();
        }

    }
}
