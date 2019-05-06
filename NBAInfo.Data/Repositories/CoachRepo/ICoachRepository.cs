using System;
using System.Collections.Generic;
using System.Text;
//import your domain models for retrieving data from your database, using an instance of your context class
//Which is the class responsible for retrieving data from the database based on the fields which are named after the database tables.
using NBAInfo.Domain.Coach;

namespace NBAInfo.Data.Repositories.CoachRepo
{
    //This interface is responsible for retrieving data using a instance of your context class.
    //No need to initialize.
    public interface ICoachRepository
    {
        IEnumerable<Coach> GetCoaches();
        Coach GetCoach(Guid id);
        Coach CreateCoach(Coach newCoach);
        void UpdateCoach(Coach updatedCoach);
        void DeleteCoach(Guid coachId);
    }
}
