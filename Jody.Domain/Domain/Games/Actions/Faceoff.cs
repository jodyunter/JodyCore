using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class Faceoff : HockeyAction
    {
        public List<Position> RecieverList { get; set; }
        public Faceoff(Game game, StreamWriter outputWriter) : base(game, outputWriter)
        {
            RecieverList = new List<Position>() { Position.RightDefense, Position.LeftDefense, Position.RightWing, Position.LeftWing };
        }

        public override ActionType OffenseActionType { get { return ActionType.FaceOff; } }

        public override ActionType DefenseActionType { get { return ActionType.FaceOff; } }

        public override int GetWinnerTimeOut { get { return 5; } }
        public override int GetLoserTimeOut { get { return 5; } }
        public override int GetGameTimeSpent { get { return 1; } }

        public override ActionType ActionType => throw new NotImplementedException();

        public override void SetDefense(Random random)
        {
            Defense = Game.Away.Centre;
        }
        public override void SetOffense(Random random)
        {
            Offense = Game.Home.Centre;
        }

        public override string GetLogMessage()
        {
            var output = string.Format("Faceoff! {0} vs {1}\n", Offense.Player.Name, Defense.Player.Name);
            output += string.Format("{0} wins it back to {1}", Winner.Player.Name, Game.PuckCarrier.Player.Name);

            return output;
        }

        public override void PreProcessForAction(Random random)
        {
            base.PreProcessForAction(random);

            Game.MakeAllPlayersAvailable();
            Game.CarrierPoints = 0;
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
            Game.PuckCarrier = receiver;
            Game.CarrierPoints += 1;
        }
    }
}
