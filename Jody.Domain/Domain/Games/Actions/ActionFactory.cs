using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class ActionFactory
    {
        public static Action CreateAction(Action previousAction, ActionType nextAction)
        {
            switch(nextAction)
            {
                case ActionType.Faceoff:
                    return new FaceOffAction(nextAction, previousAction);                    
                default:
                    throw new ApplicationException("Could not find next action: " + nextAction);
            }
        }
    }
}
