using Jody.Domain.Repositories;
using Jody.ViewModels;
using System.Linq;
using System.Collections.Generic;
using Jody.Services.ModelMappers;
using AutoMapper;
using Jody.Domain;

namespace Jody.Services
{
    public class TeamService:ITeamService
    {
        public ITeamRepository TeamRepository;
        public IMapper Mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            TeamRepository = teamRepository;
            Mapper = mapper;
        }

        public IEnumerable<TeamViewModel> GetAll()
        {
            var data = TeamRepository.GetAll();

            var models = new List<TeamViewModel>();

            data.ToList().ForEach(t =>
            {
                models.Add(Mapper.Map<Team, TeamViewModel>(t));
            });

            return models;
        }
    }
}
