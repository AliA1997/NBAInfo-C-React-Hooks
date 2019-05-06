using System;
using System.Collections.Generic;
using System.Text;
//import your Domain Models since they would be returned from the database via a directive
using NBAInfo.Domain.Team;

namespace NBAInfo.Data.Repositories.TeamRepo
{
    public interface ITeamRepository
    {
        IEnumerable<Domain.Team.Team> GetTeams();
        Team GetTeam(Guid teamId);
        Team CreateTeam(Team createdTeam);
        void UpdateTeam(Team updatedTeam);
        void DeleteTeam(Guid teamId);
    }
}
