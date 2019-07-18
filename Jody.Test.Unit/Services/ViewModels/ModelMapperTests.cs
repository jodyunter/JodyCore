using Jody.Domain;
using Jody.Test.Unit.Services.TestConfiguration;
using Jody.ViewModels;
using Xunit;
using static Xunit.Assert;

namespace Jody.Test.Unit.Services.ViewModels
{
    public class ModelMapperTests
    {
        [Fact]
        public void ShouldMapTeamToTeamViewModel()
        {
            var config = SetupConfigurationForTests();

            var name = "Test 1";
            var data = new Team() { Name = name };
            var mapper = config.Mapper;
            
            var model = mapper.Map<Team, TeamViewModel>(data);

            Equal(name, model.Name);
            Equal(name, data.Name);
        }

        [Fact]
        public void ShouldMapTeamViewModelToTeam()
        {
            var config = SetupConfigurationForTests();

            var name = "Test 1";
            var data = new TeamViewModel() { Name = name };
            var mapper = config.Mapper;

            var model = mapper.Map<TeamViewModel, Team>(data);

            Equal(name, model.Name);
            Equal(name, data.Name);
        }

        private TestServiceConfiguration SetupConfigurationForTests()
        {
            return new TestServiceConfiguration();
        }
    }
}
