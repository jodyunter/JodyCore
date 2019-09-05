using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public class GameTeam
    {
        public Game Game { get; set; }
        public Team Team { get; set; }
        public GameTeamStats Stats { get; set; }
        public IEnumerable<GamePlayer> Roster { get; set; }        

        public GamePlayer Centre { get; set; }
        public GamePlayer LeftWing { get; set; }
        public GamePlayer RightWing { get; set; }
        public GamePlayer RightDefense { get; set; }
        public GamePlayer LeftDefense { get; set; }
        public GamePlayer Goalie { get; set; }       
        public GameTeamType HomeOrAway { get; set; }
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
                case Position.Goalie:
                    return Goalie;
                case Position.None:
                    return null;
                default:
                    throw new ApplicationException("Can't find position: " + position);
            }
        }
        
        public Position GetPositionFromList(List<Position> positions, Random random)
        {
            var available = new List<Position>();

            positions.ForEach(p =>
            {
                if (IsPlayerAvailable(p))
                {
                    available.Add(p);
                }
            });

            if (available.Count > 0)
            {
                return available[random.Next(available.Count)];
            }
            else
            {
                return Position.None;
            }
        }
        public bool IsPlayerAvailable(Position position)
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

        public void ReduceTimeUntilAvailable()
        {
            Centre.ReduceTimeUntilAvailable();
            LeftWing.ReduceTimeUntilAvailable();
            RightWing.ReduceTimeUntilAvailable();
            LeftDefense.ReduceTimeUntilAvailable();
            RightDefense.ReduceTimeUntilAvailable();
            Goalie.ReduceTimeUntilAvailable();
        }
        
    }
}
