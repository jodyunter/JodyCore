using System.Collections.Generic;
using System.Linq;
using Jody.Domain;
using Jody.Domain.Repositories;

namespace Jody.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public IEnumerable<Team> GetAll()
        {
            return new List<Team>()
            {
                new Team() {Name="Team 1" },
                new Team() {Name="Team 2" },
                new Team() {Name="Team 3" },
                new Team() {Name="Team 4" },
                new Team() {Name="Team 5" },
                new Team() {Name="Team 6" },
            };
        }

        public Team GetByName(string name)
        {
            return GetAll().ToList().Where(t => t.Name.Equals(name)).FirstOrDefault();
        }
    }
}
