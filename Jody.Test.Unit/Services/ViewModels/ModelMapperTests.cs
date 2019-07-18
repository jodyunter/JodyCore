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
            bool active = false;
            int firstYear = 1;
            var data = new Team() { Name = name, Active = active, FirstYear = firstYear };
            var mapper = config.Mapper;
            
            var model = mapper.Map<Team, TeamViewModel>(data);

            Equal(name, model.Name);
            Equal(active, model.Active);
            Equal(firstYear, model.FirstYear);
            Equal(name, data.Name);
            Equal(name, data.Name);
            Equal(active, data.Active);
            Equal(firstYear, data.FirstYear);

        }

        [Fact]
        public void ShouldMapTeamViewModelToTeam()
        {
            var config = SetupConfigurationForTests();

            var name = "Test 1";
            bool active = false;
            int firstYear = 1;
            var data = new Team() { Name = name, Active = active, FirstYear = firstYear };
            var mapper = config.Mapper;

            var model = mapper.Map<Team, TeamViewModel>(data);

            Equal(name, model.Name);
            Equal(active, model.Active);
            Equal(firstYear, model.FirstYear);
            Equal(name, data.Name);
            Equal(name, data.Name);
            Equal(active, data.Active);
            Equal(firstYear, data.FirstYear);
        }

        private TestServiceConfiguration SetupConfigurationForTests()
        {
            return new TestServiceConfiguration();
        }
    }
}
