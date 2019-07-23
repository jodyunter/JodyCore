using Jody.Domain;
using Jody.Domain.Repositories;
using Jody.Services;
using Jody.Test.Unit.Services.TestConfiguration;
using Moq;
using Xunit;
using static Xunit.Assert;
namespace Jody.Test.Unit.Services
{
    public class TeamServiceTests
    {
        [Fact]             
        public void ShouldGetTeamByName()
        {
            var bindings = new TestServiceConfiguration();

            //data to return
            var team1 = new Team() { Name = "Team 1", Active = false, FirstYear = 15 };

            //mock the methods we'll use
            var teamRepository = new Mock<ITeamRepository>();
            teamRepository.Setup(x => x.GetByName("Team 1")).Returns(team1);

            //make the service call
            var service = new TeamService(teamRepository.Object, bindings.Mapper);

            var model = service.GetByName("Team 1");
            Equal(team1.Name, model.Name);
        }
    }
}
