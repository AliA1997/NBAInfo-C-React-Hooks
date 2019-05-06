using System;
using System.Collections.Generic;
using System.Text;
using NBAInfo.Services.ViewModels;

namespace NBAInfo.Services.Services.Team
{
    public interface ITeamService
    {
        IEnumerable<TeamViewModel> GetTeams();
        TeamViewModel GetTeam(Guid teamId);
        TeamViewModel CreateTeam(TeamViewModel createdTeam);
        void UpdateTeam(TeamViewModel updatedTeam);
        void DeleteTeam(Guid teamId);
    }
}
