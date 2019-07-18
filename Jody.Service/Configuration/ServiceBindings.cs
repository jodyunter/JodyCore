using System;
using System.Collections.Generic;
using System.Text;
using Jody.Data.Repositories;
using Jody.Domain.Repositories;
using Jody.Services;
using Ninject.Modules;
using AutoMapper;
namespace Jody.Services.Configuration
{
    public class ServiceBindings:NinjectModule
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

        public virtual void SetupRepositories()
        {
            Bind<ITeamRepository>().To<TeamRepository>();
        }

        public virtual void SetupServices()
        {
            Bind<ITeamService>().To<TeamService>();
        }

        public virtual void SetupAutoMapper()
        {
            Bind<IMapper>().ToConstructor(c => new Mapper(AutoMapperConfiguration.GetConfiguration())).InSingletonScope();
        }
    }
}
