using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class Faceoff : Action
    {
        public List<Position> RecieverList { get; set; }
        public Faceoff(Game game, StreamWriter outputWriter) : base(game, outputWriter)
        {
            RecieverList = new List<Position>() { Position.RightDefense, Position.LeftDefense, Position.RightWing, Position.LeftWing };
        }

        public override ActionType OffenseActionType { get { return ActionType.FaceOff; } }

        public override ActionType DefenseActionType { get { return ActionType.FaceOff; } }

        public override int GetWinnerTimeOut { get { return 1; } }
        public override int GetLoserTimeOut { get { return 1; } }
        public override int GetGameTimeSpent { get { return 1; } }

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

        public override Action GetNextAction(Random random)
        {
            if (GetRandomResult(random, 50, 50))
            {
                return new Pass(Game, OutputStream);
            }
            else
            {
                return new Carry(Game, OutputStream);
            }
        }

        public override void PreProcessForAction(Random random)
        {
            Game.MakeAllPlayersAvailable();
            Game.CarrierPoints = 0;
        }

        public override void ProcessResultsForAction(bool result, Random random)
        {
            if (!result)
            {
                Game.ChangePossession();
            }
            //choose player who gets the puck
            var team = Game.GetOffense();
            var receiver = team.GetPlayerByPosition(team.GetPositionFromList(RecieverList, random));
            Game.PuckCarrier = receiver;
            Game.CarrierPoints += 1;
        }

        public override void ProcessStat(bool result, GamePlayer offense, GamePlayer defense)
        {
            throw new NotImplementedException();
        }
    }
}
