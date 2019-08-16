using Jody.Domain.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Scheduling
{
    public class ScheduleGame
    {
        public ScheduleDay Day { get; set; }
        public Game Game { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public bool Complete { get; set; }
        public bool Processed { get; set; }
    }
}
