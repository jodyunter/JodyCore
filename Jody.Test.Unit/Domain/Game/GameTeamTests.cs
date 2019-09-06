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
        public static GameTeam SetupTeam(string name)
        {
            return new GameTeam()
            {
                Team = new Team() { Name = name },
                Centre = GamePlayerTests.SetupPlayer("Centre Guy"),
                LeftWing = GamePlayerTests.SetupPlayer("Left Wing Guy"),
                RightWing = GamePlayerTests.SetupPlayer("Right Wing Guy"),
                LeftDefense = GamePlayerTests.SetupPlayer("Left Defense Guy"),
                RightDefense = GamePlayerTests.SetupPlayer("Right Defense Guy"),
                Goalie = GamePlayerTests.SetupPlayer("Goalie Guy")
            };
        }

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

        [Theory]
        [InlineData(Position.Centre, 0, true)]
        [InlineData(Position.Centre, 15, false)]
        [InlineData(Position.LeftWing, 0, true)]
        [InlineData(Position.LeftWing, 15, false)]
        [InlineData(Position.RightWing, 0, true)]
        [InlineData(Position.RightWing, 15, false)]
        [InlineData(Position.LeftDefense, 0, true)]
        [InlineData(Position.LeftDefense, 15, false)]
        [InlineData(Position.RightDefense, 0, true)]
        [InlineData(Position.RightDefense, 15, false)]
        [InlineData(Position.Goalie, 0, true)]
        [InlineData(Position.Goalie, 15, false)]
        public void ShouldTestIsPlayerAvailable(Position position, int timeRemaining, bool expected)
        {
            var team = SetupTeam("Team 1");
            team.GetPlayerByPosition(position).TimeUntilAvailable = timeRemaining;
            Equal(expected, team.IsPlayerAvailable(position));

        }

        [Fact]
        public void ShouldMakeAllAvailable()
        {
            var team = SetupTeam("Team 1");
            team.Centre.TimeUntilAvailable = 15;
            team.LeftWing.TimeUntilAvailable = 10;
            team.RightWing.TimeUntilAvailable = 5;
            team.LeftDefense.TimeUntilAvailable = 25;
            team.RightDefense.TimeUntilAvailable = 35;

            team.MakeAllPlayersAvailable();

            True(team.IsPlayerAvailable(Position.Centre));
            True(team.IsPlayerAvailable(Position.LeftWing));
            True(team.IsPlayerAvailable(Position.RightWing));
            True(team.IsPlayerAvailable(Position.LeftDefense));
            True(team.IsPlayerAvailable(Position.RightDefense));
        }

        [Fact]
        public void ShouldReduceTimeUntilAvailable()
        {
            var team = SetupTeam("Team 1");
            team.Centre.TimeUntilAvailable = 15;
            team.LeftWing.TimeUntilAvailable = 10;
            team.RightWing.TimeUntilAvailable = 5;
            team.LeftDefense.TimeUntilAvailable = 25;
            team.RightDefense.TimeUntilAvailable = 35;

            team.ReduceTimeUntilAvailable();

            Equal(14,team.Centre.TimeUntilAvailable);
            Equal(9, team.LeftWing.TimeUntilAvailable);
            Equal(4, team.RightWing.TimeUntilAvailable);
            Equal(24, team.LeftDefense.TimeUntilAvailable);
            Equal(34, team.RightDefense.TimeUntilAvailable);
        }
    }
}
