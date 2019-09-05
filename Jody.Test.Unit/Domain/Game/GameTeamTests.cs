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
        [Theory]
        [InlineData("Centre Guy", Position.Centre)]
        [InlineData("Left Wing Guy", Position.LeftWing)]
        [InlineData("Right Wing Guy", Position.RightWing)]
        [InlineData("Left Defense Guy", Position.LeftDefense)]
        [InlineData("Right Defense Guy", Position.RightDefense)]
        [InlineData("Goalie Guy", Position.Goalie)]
        public void ShouldGetPlayerByPosition(string expectedName, Position position)
        {
            var team = SetupTeam("Team 1");
            Equal(expectedName, team.GetPlayerByPosition(position).Player.Name);
            Null(team.GetPlayerByPosition(Position.None));
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
