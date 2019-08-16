using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public Team Team { get; set; }
        public int Number { get; set; }
        public bool Active { get; set; }
        public int Age { get; set; }
    }
}
