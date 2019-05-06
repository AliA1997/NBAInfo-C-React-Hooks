using System;
using System.Collections.Generic;
using System.Text;
//improt linq for performing database methods to your persistance layer. 
using System.Linq;
//Import your CoachRepository that will be used for retrieving data from database.
using NBAInfo.Data.Repositories.CoachRepo;
using NBAInfo.Domain.Coach;
//import your ViewModels
using NBAInfo.Services.ViewModels;
//import your Factory for creating view models.
using NBAInfo.Services.Factory;

namespace NBAInfo.Services.Services.Coach.Impl
{
    public class CoachService : ICoachService
    {
        //Define a private variable that will follow the ICoachRepository interface since you don't want to have your repo initialize upon creation.
        private ICoachRepository _repository;
        //Define a constructor that will take a ICoachRepository interface argument, and have your repository private variable assigned to repository argument.
        public CoachService(ICoachRepository repository)
        {
            _repository = repository;
        }
        //Define a method that will loop throught the results, and a create view model for each instance of your CoachDomain, and create a view model from it.
        public IEnumerable<CoachViewModel> GetCoaches()
        {
            IEnumerable<CoachViewModel> coaches = _repository.GetCoaches().Select(coach => ModelFactory.CreateViewModel(coach));
            return coaches;
        }
        public CoachViewModel GetCoach(Guid coachId)
        {
            var coachToReturn = _repository.GetCoach(coachId);
            return ModelFactory.CreateViewModel(coachToReturn);
        }
        public CoachViewModel CreateCoach(CoachViewModel createdCoach)
        {
            var coachToAdd = ModelFactory.CreateDomainModel(createdCoach);
            _repository.CreateCoach(coachToAdd);
            return createdCoach;
        }
        public void UpdateCoach(CoachViewModel updatedCoach)
        {
            var coachToUpdate = ModelFactory.CreateDomainModel(updatedCoach);
            _repository.UpdateCoach(coachToUpdate);
            return;
        }
        public void DeleteCoach(Guid coachId)
        {
            _repository.DeleteCoach(coachId);
            return;
        }
    }
}
