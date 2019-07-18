using System.Collections.Generic;
using System.Linq;
using Jody.Domain;
using Jody.Domain.Repositories;

namespace Jody.Test.Services.TestRepositories
{
    public class TestTeamRepository : ITeamRepository
    {
        public IEnumerable<Team> GetAll()
        {
            return new List<Team>()
            {
                new Team() {Name="Team 1", Active = true, FirstYear = 1 },
                new Team() {Name="Team 2", Active = true, FirstYear = 1 },
                new Team() {Name="Team 3", Active = true, FirstYear = 1 },
                new Team() {Name="Team 4", Active = false, FirstYear = 1 },
                new Team() {Name="Team 5", Active = true, FirstYear = 1 },
                new Team() {Name="Team 6", Active = false, FirstYear = 1 },
            };
        }


        public Team GetByName(string name)
        {
            return GetAll().ToList().Where(t => t.Name.Equals(name)).FirstOrDefault();
        }
    }
}
