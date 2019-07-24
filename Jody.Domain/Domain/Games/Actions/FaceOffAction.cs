using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class FaceOffAction : Action
    {
        public override Action GetNextAction()
        {
            //next action should be based on the current action, the player preferences, and how many opponents there are
            
            throw new NotImplementedException();
        }

        public override void ProcessAction(Action lastAction, Random random)
        {
            throw new NotImplementedException();
        }
    }
}
