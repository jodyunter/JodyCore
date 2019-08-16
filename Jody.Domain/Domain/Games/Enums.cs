using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public enum GameStatus
    {
        NotStarted = 0,
        Started = 1,
        Finished = 2,
        Processed = 3
    }

    public enum Position
    {
        Bench = 0,
        Centre = 1,
        LeftWing = 2,
        RightWing = 3,
        LeftDefense = 4,
        RightDefense = 5
    }

    public enum GameTeamType
    {
        Home = 0,
        Away = 1
    }

    public enum GameResult
    {
        Win = 0,
        Loss = 1,
        Ties = 2,
        Undecided = 3,
        Incomplete = 4
    }
}
