using System;
using System.Collections.Generic;
using System.Text;
using static Xunit.Assert;
using Xunit;
using Jody.Domain.Games;
using Jody.Domain;
using System.Linq;


namespace Jody.Test.Unit.Domain.Game
{
    public class GamePlayerTests
    {
        public static GamePlayer SetupPlayer(string name)
        {
            return SetupPlayer(name, 0);
        }

        public static GamePlayer SetupPlayer(string name, int timeUntilAvailable)
        {            
            return new GamePlayer()
            {
                Player = new Player()
                {
                    Name = name,
                    FaceOffSkill = 1,
                    InterceptSkill = 2,
                    PassingSkill = 3,
                    CarrySkill = 4,
                    ForeCheckSkill = 5
                },
                TimeUntilAvailable = timeUntilAvailable
            };
        }
        

        [Fact]
        public void ShouldMakeAvailable()
        {
            var player = SetupPlayer("Player 1");
            Equal(0, player.TimeUntilAvailable);
            player.TimeUntilAvailable = 15;
            NotEqual(0, player.TimeUntilAvailable);
            player.MakeAvailable();
            Equal(0, player.TimeUntilAvailable);
        }

        [Fact]
        public void ShouldReduceTime()
        {
            var player = SetupPlayer("Player 1");
            Equal(0, player.TimeUntilAvailable);
            player.TimeUntilAvailable = 15;
            NotEqual(0, player.TimeUntilAvailable);
            player.ReduceTimeUntilAvailable();
            Equal(14, player.TimeUntilAvailable);
        }

        [Fact]
        public void ShouldNotReduceTimeBecause0()
        {
            var player = SetupPlayer("Player 1");
            Equal(0, player.TimeUntilAvailable);
            player.ReduceTimeUntilAvailable();
            Equal(0, player.TimeUntilAvailable);
        }

        [Fact]
        public void ShouldGetSkillForActionType()
        {
            var player = SetupPlayer("My Player");

            Equal(1, player.GetSkillForActionType(ActionType.FaceOff));
            Equal(2, player.GetSkillForActionType(ActionType.Intercept));
            Equal(3, player.GetSkillForActionType(ActionType.Pass));
            Equal(4, player.GetSkillForActionType(ActionType.Carry));
            Equal(5, player.GetSkillForActionType(ActionType.ForeCheck));

            //verify each has a value
            foreach (var item in Enum.GetValues(typeof(ActionType)))
            {
                True(player.GetSkillForActionType((ActionType)item) >= 0);
            }

            
        }
    }
}
