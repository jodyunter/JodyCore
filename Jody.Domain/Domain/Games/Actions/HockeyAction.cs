using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public abstract class HockeyAction:Action
    {
        public HockeyAction(Game game, StreamWriter output):base(game, output)
        {

        }

        public override Action CreateAction(ActionType actionType, Action previousAction)
        {
            switch (previousAction.ActionType)
            {
                case ActionType.FaceOff:
                    return new Faceoff(previousAction.Game, previousAction.OutputStream);                    
                case ActionType.Carry:
                    return new Carry(previousAction.Game, previousAction.OutputStream);
                case ActionType.Pass:
                    return new Faceoff(previousAction.Game, previousAction.OutputStream);
                case ActionType.Shoot:
                    return new Shoot(previousAction.Game, previousAction.OutputStream);
                case ActionType.Score:
                    return new Score(previousAction.Game, previousAction.OutputStream);
                case ActionType.Scramble:
                    return new Scramble(previousAction.Game, previousAction.OutputStream);
                case ActionType.Freeze:
                    return new Freeze(previousAction.Game, previousAction.OutputStream);
                default:
                    throw new NotImplementedException("Action type :" + previousAction.ActionType + " Hasn't been defined here yet");
            }
        }
        public override Action GetNextAction(Random random, Action previousAction)
        {
            var next = ActionType.FaceOff;

            if (previousAction.ActionType == ActionType.BeginGame)
            {
                next = ActionType.FaceOff;
            }
            else
            {
                switch (previousAction.ActionType)
                {
                    case ActionType.FaceOff:
                        next = ChooseAction(random, ActionType.Carry, ActionType.Pass);
                        break;
                    case ActionType.Carry:
                        next = ChooseAction(random, ActionType.Carry, ActionType.Pass, ActionType.Shoot);
                        break;
                    case ActionType.Pass:
                        next = ChooseAction(random, ActionType.Carry, ActionType.Pass, ActionType.Shoot);
                        break;
                    case ActionType.Shoot:
                        if (previousAction.Result) next = ActionType.Shoot;
                        else next = ActionType.Scramble;
                        break;
                    case ActionType.Score:
                        if (previousAction.Result) next = ActionType.FaceOff;
                        else next = ActionType.Freeze;
                        break;
                    case ActionType.Scramble:
                        next = ChooseAction(random, ActionType.Carry, ActionType.Pass, ActionType.Shoot);
                        break;
                    case ActionType.Freeze:
                        if (previousAction.Result) next = ActionType.FaceOff;
                        else next = ActionType.Scramble;
                        break;
                    default:
                        throw new NotImplementedException("Action type :" + previousAction.ActionType + " Hasn't been defined here yet");
                }
            }

            return CreateAction(next);
        }
    }
}
