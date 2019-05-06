using System;
using System.Collections.Generic;
using System.Text;
//import your view models using a directive
using NBAInfo.Services.ViewModels;

namespace NBAInfo.Services.Services.Coach
{
    public interface ICoachService
    {
        IEnumerable<CoachViewModel> GetCoaches();
        CoachViewModel GetCoach(Guid coachId);
        CoachViewModel CreateCoach(CoachViewModel createdCoach);
        void UpdateCoach(CoachViewModel updatedCoach);
        void DeleteCoach(Guid coachId);
    }
}
