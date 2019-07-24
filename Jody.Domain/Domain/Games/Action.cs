using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Games
{
    public abstract class Action
    {
        public ActionType ActionType { get; set; }
        public Game Game { get; set; }
        public GamePlayer PuckCarrier { get; set; }
        public GamePlayer Opponent { get; set; }
        public GamePlayer Winner { get; set; }
        public GamePlayer Loser { get; set; }
        public int Period { get; set; }
        public int Moment { get; set; }
        public int Order { get; set; }        
        public GamePlayer WhoGotThePuck { get; set; }
        public bool Processed { get; set; }

        public abstract void GetNextAction(Random random);
        public abstract void ProcessAction(Random random);

    }
}
