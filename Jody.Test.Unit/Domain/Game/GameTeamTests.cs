using Jody.Domain;
using Jody.Domain.Games;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Xunit.Assert;
namespace Jody.Test.Unit.Domain.Game
{
    
    public class GameTeamTests
    {
        [Fact]
        public void ShouldGetPlayerByPosition()
        {
            var team = SetupTeam("Team 1");
            Equal("Centre Guy", team.GetPlayerByPosition(Position.Centre).Player.Name);
        }

        public GameTeam SetupTeam(string name)
        {
            return new GameTeam()
            {
                Team = new Team() { Name = name },
                Centre = SetupPlayer("Centre Guy"),
                LeftWing = SetupPlayer("Left Wing Guy"),
                RightWing = SetupPlayer("Right Wing Guy"),
                LeftDefense = SetupPlayer("Left Defense Guy"),
                RightDefense = SetupPlayer("Right Defense Guy"),
                Goalie = SetupPlayer("Goalie Guy")
            };

        }
        public GamePlayer SetupPlayer(string name)
        {
            return new GamePlayer() { Player = new Player() { Name = name }, TimeUntilAvailable = 0 };
        }
    }
}
