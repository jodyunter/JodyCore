using System.Collections.Generic;
using System.Linq;
using Jody.Domain;
using Jody.Domain.Repositories;

namespace Jody.Test.Services.TestServiceRepositories
{
    public class TestTeamRepository : ITeamRepository
    {
        public IEnumerable<Team> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Team GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
