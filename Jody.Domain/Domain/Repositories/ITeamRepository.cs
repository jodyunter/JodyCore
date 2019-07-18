using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Domain.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        Team GetByName(string name);
    }
}
