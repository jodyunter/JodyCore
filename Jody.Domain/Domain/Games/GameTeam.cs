using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public class GameTeam
    {
        public Game Game { get; set; }
        public GameTeamStats Stats { get; set; }
        public IEnumerable<GamePlayer> Roster { get; set; }        

        public GamePlayer Centre { get; set; }
        public GamePlayer LeftWing { get; set; }
        public GamePlayer RightWing { get; set; }
        public GamePlayer RightDefense { get; set; }
        public GamePlayer LeftDefense { get; set; }
        public GamePlayer Goalie { get; set; }       
        
        //todo add bench positions
        public GamePlayer GetPlayerByPosition(Position position)
        {
            switch(position)
            {
                case Position.Centre:
                    return Centre;
                case Position.LeftWing:
                    return LeftWing;
                case Position.RightWing:
                    return RightWing;
                case Position.LeftDefense:
                    return LeftDefense;
                case Position.RightDefense:
                    return RightDefense;
                default:
                    throw new ApplicationException("Can't find position: " + position);
            }
        }
        
        public bool IsPlayerActive(Position position)
        {
            return GetPlayerByPosition(position).TimeUntilAvailable <= 0;
        }

        public void MakeAllPlayersAvailable()
        {
            Centre.MakeAvailable();
            LeftWing.MakeAvailable();
            RightWing.MakeAvailable();
            LeftDefense.MakeAvailable();
            RightDefense.MakeAvailable();
            Goalie.MakeAvailable();

        }
        
    }
}
