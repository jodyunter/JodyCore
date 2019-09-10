using System;
using System.Collections.Generic;
using System.Text;
using static Xunit.Assert;
using Xunit;
using Jody.Domain.Games.Actions;
using System.IO;
using Jody.Domain.Games;
using System.Linq;

namespace Jody.Test.Unit.Domain.Game.Actions
{
    public class FaceoffActionTests
    {
        public static Faceoff CreateFaceOff()
        {
            MemoryStream writer = new MemoryStream();
            return new Faceoff(null, new StreamWriter(writer));
        }
        [Fact]
        public void ShouldTestRecieverList()
        {
            var faceoff = CreateFaceOff();

            Equal(5, faceoff.RecieverList.Count);
            Single(faceoff.RecieverList.Where(r => r == Position.Centre).ToList());
            Single(faceoff.RecieverList.Where(r => r == Position.LeftWing).ToList());
            Single(faceoff.RecieverList.Where(r => r == Position.RightWing).ToList());
            Single(faceoff.RecieverList.Where(r => r == Position.LeftDefense).ToList());
            Single(faceoff.RecieverList.Where(r => r == Position.RightDefense).ToList());
        }

        [Fact]
        public void ShouldCheckActionTypes()
        {
            var faceoff = CreateFaceOff();

            Equal(ActionType.FaceOff, faceoff.OffenseActionType);
            Equal(ActionType.FaceOff, faceoff.DefenseActionType);
        }
    }
}
