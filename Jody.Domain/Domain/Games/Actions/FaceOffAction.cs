using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class FaceOffAction : Action
    {

        public FaceOffAction(Game game, int period, int moment, Action previousAction)
            :base(ActionType.Faceoff, game, period, moment, previousAction)
        {

        }

        public override void SetupAction(Random random)
        {
            PuckCarrier = Game.Home.Centre;
            Opponent = Game.Away.Centre;
        }

        public override void GetNextAction(Random random)
        {
            throw new NotImplementedException();
        }

        public override void ProcessAction(Random random)
        {
            //determine winner
            Winner = PuckCarrier;
            Loser = Opponent;

            //find the next player

            throw new NotImplementedException();
        }

    }
}
