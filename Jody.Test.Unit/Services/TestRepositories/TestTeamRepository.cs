using System;
using System.Collections.Generic;
using System.Text;
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
                new Team() {Name="Team 1" },
                new Team() {Name="Team 2" },
                new Team() {Name="Team 3" },
                new Team() {Name="Team 4" },
                new Team() {Name="Team 5" },
                new Team() {Name="Team 6" },
            };
        }
    }
}
