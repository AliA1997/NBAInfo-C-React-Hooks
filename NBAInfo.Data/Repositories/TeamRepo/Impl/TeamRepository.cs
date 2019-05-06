using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//import domain models which would be used for retrieving data.
using NBAInfo.Domain.Team;
//import your context 
using NBAInfo.Data.Database;

namespace NBAInfo.Data.Repositories.TeamRepo.Impl
{
    public class TeamRepository : ITeamRepository
    {
        //Define a private variable that is a AppContext type, which is responsible for retrieving data from database.
        private NBAInfoContext _context;
        //Define a constructor that will assign the context argument to your private context variable.
        public TeamRepository(NBAInfoContext context)
        {
            _context = context;
        }
        //Follow your interface by returning a variable.
        public IEnumerable<Team> GetTeams()
        {
            IEnumerable<Team> teams = _context.Teams;
            return teams;
        }
        public Team GetTeam(Guid teamId)
        {
            Team teamToReturn = _context.Teams.FirstOrDefault(team => team.Id == teamId);
            return teamToReturn;
        }
        public Team CreateTeam(Team createdTeam)
        {
            _context.Teams.Add(createdTeam);
            _context.SaveChanges();
            return createdTeam;
        }
        public void UpdateTeam(Team updatedTeam)
        {
            _context.Teams.Update(updatedTeam);
            _context.SaveChanges();
            return;
        }
        public void DeleteTeam(Guid teamId)
        {
            Team teamToDelete = _context.Teams.FirstOrDefault(team => team.Id == teamId);
            if (teamToDelete != null)
            {
                _context.Teams.Remove(teamToDelete);
                _context.SaveChanges();
            }
            return;
        }
    }
}
