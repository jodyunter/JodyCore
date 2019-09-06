using System;
using System.Collections.Generic;
using System.Text;
using static Xunit.Assert;
using Xunit;
using Jody.Domain.Games;
using Jody.Domain;

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
            return new GamePlayer() { Player = new Player() { Name = name }, TimeUntilAvailable = timeUntilAvailable };
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
    }
}
