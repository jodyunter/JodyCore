using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public class GoalData
    {
        public int Period { get; set; }
        public int Time { get; set; }
        public int Order { get; set; }
        public GameTeam Team { get; set; }
        public GamePlayer Scorer { get; set; }
        public GamePlayer AssistPrimary { get; set; }
        public GamePlayer AssistSecondary { get; set; }
        public GamePlayer TeamCentre { get; set; }
        public GamePlayer TeamLeftWing { get; set; }
        public GamePlayer TeamRightWing { get; set; }
        public GamePlayer TeamRightDefense { get; set; }
        public GamePlayer TeamLeftDefense { get; set; }
        public GamePlayer TeamGoalie { get; set; }
        public GamePlayer OpponentCentre { get; set; }
        public GamePlayer OpponentLeftWing { get; set; }
        public GamePlayer OpponentRightWing { get; set; }
        public GamePlayer OpponentRightDefense { get; set; }
        public GamePlayer OpponentLeftDefense { get; set; }
        public GamePlayer OpponentGoalie { get; set; }
    }
}
