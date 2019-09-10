﻿using System;
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
        RightDefense = 5,
        Goalie = 6,
        None = 7

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

    public enum ActionType
    {
        FaceOff = 0,
        Pass = 1,
        Intercept = 2,
        Carry = 3,
        Shoot = 4,
        Score = 5,
        Save = 6,
        Freeze = 7,
        Scramble = 8
    }
}
