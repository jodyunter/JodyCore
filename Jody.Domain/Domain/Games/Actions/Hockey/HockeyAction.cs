using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions.Hockey
{
    public abstract class HockeyAction:Action
    {
        public HockeyAction(Game game, StreamWriter output):base(game, output)
        {

        }

        public override Action CreateAction(ActionType actionType, Game game, StreamWriter outputStream)
        {
            switch (actionType)
            {
                case ActionType.FaceOff:
                    return new Faceoff(game, outputStream);                    
                case ActionType.Carry:
                    return new Carry(game, outputStream);
                case ActionType.Pass:
                    return new Faceoff(game, outputStream);
                case ActionType.Shoot:
                    return new Shoot(game, outputStream);
                case ActionType.Score:
                    return new Score(game, outputStream);
                case ActionType.Scramble:
                    return new Scramble(game, outputStream);
                case ActionType.Freeze:
                    return new Freeze(game, outputStream);
                default:
                    throw new NotImplementedException("Action type :" + actionType + " Hasn't been defined here yet");
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

            return CreateAction(next, previousAction.Game, previousAction.OutputStream);
        }
    }
}
