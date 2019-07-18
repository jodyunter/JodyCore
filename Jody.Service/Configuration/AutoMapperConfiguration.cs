using AutoMapper;
using Jody.Domain;
using Jody.ViewModels;


namespace Jody.Services.Configuration
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration GetConfiguration()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {                
                cfg.CreateMap<Team, TeamViewModel>();
                cfg.CreateMap<TeamViewModel, Team>();
            });

            return mapperConfiguration;
        }
    }
}
