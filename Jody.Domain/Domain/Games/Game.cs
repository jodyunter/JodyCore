using Jody.Domain.Games.Actions;
using System;
using System.IO;
using Action = Jody.Domain.Games.Actions.Action;

namespace Jody.Domain.Games
{
    public class Game
    {
        public int Number { get; set; }        
        public GameTeam Home { get; set; }
        public GameTeam Away { get; set; }
        public GamePlayer PuckCarrier { get; set; }
        
        public int CurrentPeriod { get; set; }
        public int CurrentTime { get; set; }
        public GameStatus Status { get; set; }
        public GameStats Stats { get; set; }
        public int CarrierPoints { get; set; }
        public GamePlayer FirstAssist { get; set; }
        public GamePlayer SecondAssist { get; set; }
        public GameTeamType Offense { get; set; }
                
        public string GameLog { get; set; }
        public StreamWriter Output { get; set; }

        public GameTeam GetOffense()
        {
            return Offense == GameTeamType.Home ? Home : Away;
        }

        public GameTeam GetDefense()
        {
            return Offense == GameTeamType.Home ? Away : Home;
        }
        //game rules, like overtime, total periods, etc
        public void PlayGame(Random random)
        {
            MakeAllPlayersAvailable();
            var firstAction = new Faceoff(this, Output);
            Action action;
            action = firstAction;

            while (!IsPeriodComplete())
            {
                action.Process(random);
                action = action.GetNextAction(random, action);
            }
        }

        public bool IsGameComplete()
        {
            throw new NotImplementedException();
        }
        public bool IsPeriodComplete()
        {
            throw new NotImplementedException();
        }

          public void ChangePossession()
        {
            CarrierPoints = 0;
            Offense = Offense == GameTeamType.Away ? GameTeamType.Home : GameTeamType.Away;
        }


        public void MakeAllPlayersAvailable()
        {
            Home.MakeAllPlayersAvailable();
            Away.MakeAllPlayersAvailable();
        }

        public bool GetResult(Random random)
        {
            return random.Next(26) >= random.Next(26);
        }

        public void ProcessAvailability()
        {
            Home.ReduceTimeUntilAvailable();
            Away.ReduceTimeUntilAvailable();
        }


    }
}
