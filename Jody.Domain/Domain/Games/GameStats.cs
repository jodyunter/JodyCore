using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public class GameStats
    {
        public Game Game { get; set; }
        IEnumerable<Action> Actions { get; set; }
    }

}
