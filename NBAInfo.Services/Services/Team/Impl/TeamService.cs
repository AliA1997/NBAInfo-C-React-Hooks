using System;
using System.Collections.Generic;
using System.Text;
//Import linq for using database methods for your persistance layer.
using System.Linq;
//import your TeamRepository which will be your persistance layer getting data from the database.
using NBAInfo.Data.Repositories.TeamRepo;
//import your ViewModels 
using NBAInfo.Services.ViewModels;
//import your Factory for creating ViewModels
using NBAInfo.Services.Factory;

namespace NBAInfo.Services.Services.Team.Impl
{
    public class TeamService : ITeamService
    {
        //Define a private variable used for retrieving data from database.
        private ITeamRepository _repository;
        //Define a constructor and assign a ITeamRepository instance to your _repository variable.
        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
        }
        //Define methods that will create a view model through each instance of a domain variable when looping through your result of yoru repositories get method.
        public IEnumerable<TeamViewModel> GetTeams()
        {
            IEnumerable<TeamViewModel> teams = _repository.GetTeams().Select(team => ModelFactory.CreateViewModel(team));
            return teams;
        }
        public TeamViewModel GetTeam(Guid teamId)
        {
            var teamToReturn = _repository.GetTeam(teamId);
            return ModelFactory.CreateViewModel(teamToReturn);
        }
        public TeamViewModel CreateTeam(TeamViewModel createdTeam)
        {
            var teamToCreate = ModelFactory.CreateDomainModel(createdTeam);
            _repository.CreateTeam(teamToCreate);
            return createdTeam;
        } 
        public void UpdateTeam(TeamViewModel updatedTeam)
        {
            var teamToUpdate = ModelFactory.CreateDomainModel(updatedTeam);
            _repository.UpdateTeam(teamToUpdate);
            return;
        }
        public void DeleteTeam(Guid teamId)
        {
            _repository.DeleteTeam(teamId);
            return;
        }
    }
}
