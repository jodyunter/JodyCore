using Jody.Domain;
using Jody.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Services.ModelMappers
{
    public static class ModelMapper
    {
        public static TeamViewModel TeamToTeamViewModel(Team input)
        {
            return new TeamViewModel() { Name = input.Name };
        }
    }
}
