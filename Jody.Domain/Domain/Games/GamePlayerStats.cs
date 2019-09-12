using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public class GamePlayerStats
    {

        public Game Game { get; set; }
        public Player Player { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }

        public int RoundsAsCentre { get; set; }
        public int RoundsAsLeftWing { get; set; }
        public int RoundsAsRightWing { get; set; }
        public int RoundsAsLeftDefense { get; set; }
        public int RoundsAsRightDefense { get; set; }
        public int RoundsAsGoalie { get; set; }

        public int FaceOffWins { get; set; }
        public int FaceOffLoses { get; set; }
        public int FaceOffsTaken { get { return FaceOffWins + FaceOffLoses; } }

        public int CarriesMade { get; set; }
        public int CarriesFailed { get; set; }
        public int CarriedAttempted { get { return CarriesFailed + CarriesMade; } }

        public int ForeChecksMade { get; set; }
        public int ForeChecksFailed { get; set; }
        public int ForeChecksAttempted { get { return ForeChecksMade+ ForeChecksFailed; } }

        public int PassesMade { get; set; }
        public int PassesIntercepted { get; set; }
        public int PassesAttempted { get { return PassesMade + PassesIntercepted; } }

        public int Interceptions { get; set; }
        public int InterceptionsMissed { get; set; }
        public int InterceptionsAttempted { get { return Interceptions + InterceptionsMissed; } }

        public int ShotsOnGoal { get; set; }
        public int ShotsBlocked { get; set; }
        public int ShotsTaken { get { return ShotsOnGoal + ShotsBlocked; } }
        public int ShotsSaved { get; set; }

        public int GoalsScored { get; set; }
        public int SavedShots { get; set; }
        

        public int BlockedShots { get; set; }
        public int BlocksMissed { get; set; }
        public int BlocksAttempted { get { return BlocksAttempted + BlocksMissed; } }

        public int GoalsAllowed { get; set; }
        public int SavesMade { get; set; }
        public int ShotsAgainst { get { return GoalsAllowed + SavesMade; } }
        public int Freezes { get; set; }
        public int FreezesFailed { get; set; }
        public int FreezesAttempted { get { return Freezes + FreezesFailed; } }

        public int ScramblesWon { get; set; }
        public int ScramblesLost { get; set; }
        public int ScramblesTotal { get { return ScramblesLost + ScramblesWon; } }
        
    }
}
