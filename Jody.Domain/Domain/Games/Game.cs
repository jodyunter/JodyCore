﻿using System;

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
        
        public string GameLog { get; set; }

        //game rules, like overtime, total periods, etc
        public void PlayGame(Random random)
        {
            if (PuckCarrier == null)
            {
                MakeAllPlayersAvailable();
            }
        }

        public bool IsGameComplete()
        {
            return false;
        }
        public bool IsPeriodComplete()
        {
            return false;
        }

        public void RunFaceOff(Random random)
        {
            CarrierPoints = 0;
            FirstAssist = null;
            SecondAssist = null;

            var centre1 = Home.Centre;
            var centre2 = Away.Centre;            

            if (GetResult(random))
            {
                PuckCarrier = centre1;
                centre1.Stats.FaceOffWins++;
                centre2.Stats.FaceOffLoses++;
            }
        }

        public void AttemptShot(Random random)
        {

        }

        public void AttemptCarry(Random random)
        {

        }

        public void AttemptPass(Random random)
        {

        }

        public void ChangePossession()
        {

        }

        public void NextAction(Random random)
        {
            if (CarrierPoints > 1)
            {
                AttemptShot(random);
            }
            else
            {
                //AttemptCarry
                //AttemptPass

            }
            //at the end
            ProcessAvailability();
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
