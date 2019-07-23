
using Jody.Domain.Repositories;
using Jody.Services.Configuration;
using Jody.Test.Services.TestServiceRepositories;

namespace Jody.Test.Unit.Services.TestConfiguration
{
    public class TestServiceBindings:ServiceBindings
    {
        public override void Load()
        {
            //repositories
            SetupRepositories();

            //services
            SetupServices();

            //automapper            
            SetupAutoMapper();
        }

        public override void SetupRepositories()
        {
            Bind<ITeamRepository>().To<TestTeamRepository>();
        }
    }
}
