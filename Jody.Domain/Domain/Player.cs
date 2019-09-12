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

        //player stats some make be calculated later on
        public int FaceOffSkill { get; set; }
        public int InterceptSkill { get; set; }
        public int PassingSkill { get; set; }        
        public int CarrySkill { get; set; }
        public int ForeCheckSkill { get; set; }
        public int ShootingSkill { get; internal set; }
        public int BlockingSkill { get; internal set; }
        public int ScoringSkill { get; internal set; }
        public int SavingSkill { get; internal set; }
        public int FreezingSkill { get; internal set; }
    }
}
