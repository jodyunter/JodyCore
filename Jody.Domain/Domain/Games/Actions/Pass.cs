﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class Pass:Action
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

        public override int GetWinnerTimeOut { get { return 2; }  }

        public override int GetLoserTimeOut { get { return 3; } }

        public override int GetGameTimeSpent { get { return 1; } }

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

        public override Action GetNextAction(Random random)
        {
            //pass, carry or shoot
            throw new NotImplementedException();
        }

        public override void PreProcessForAction(Random random)
        {
            throw new NotImplementedException();
        }

        public override void ProcessResultsForAction(Random random)
        {
            throw new NotImplementedException();
        }

        public override void ProcessStat(GamePlayer offense, GamePlayer defense)
        {
            throw new NotImplementedException();
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
