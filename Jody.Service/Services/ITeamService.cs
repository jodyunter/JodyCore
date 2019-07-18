using Jody.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Services
{
    public interface ITeamService
    {
        IEnumerable<TeamViewModel> GetAll();
        TeamViewModel GetByName(string name);
    }
}
