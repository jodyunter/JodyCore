using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jody.Domain.Games.Actions
{
    public class Pass:Action
    {
        //passing has a third player involved, will need to override approrpiately
        public Pass(Game game, StreamWriter outputWriter) : base(game, outputWriter)
        {

        }
    }
}
