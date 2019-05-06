using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
//import your context that will be responsible for retrieving data.
using NBAInfo.Data.Database;
//import your domain models for your Coach data.
using NBAInfo.Domain.Coach;

namespace NBAInfo.Data.Repositories.CoachRepo.Impl
{
    public class CoachRepository : ICoachRepository
    {
        //Define a private  of a type of your AppCOntext that is responsible for retrieving data from database.
        private NBAInfoContext _context;
        //Have a constructor that will assign a Context instance to youvariabler private variable.
        public CoachRepository(NBAInfoContext context)
        {
            _context = context;
        }
        //Have a method that will return all the coaches.
        public IEnumerable<Coach> GetCoaches()
        {
            IEnumerable<Coach> coaches = _context.Coaches.ToList();
            return coaches;
        }
        public Coach GetCoach(Guid id)
        {
            Coach coachToReturn = _context.Coaches.FirstOrDefault(coach => coach.Id == id);
            return coachToReturn;
        }
        public Coach CreateCoach(Coach newCoach)
        {
            _context.Coaches.Add(newCoach);
            _context.SaveChanges();
            return newCoach;
        }
        public void UpdateCoach(Coach updatedCoach)
        {
            _context.Coaches.Update(updatedCoach);
            _context.SaveChanges();
            return;
        }
        public void DeleteCoach(Guid coachId)
        {
            //Assign the coach to delete.
            Coach coachToDelete = _context.Coaches.FirstOrDefault(coach => coach.Id == coachId);
            if (coachToDelete != null)
            {
                _context.Coaches.Remove(coachToDelete);
                _context.SaveChanges();
            }
            return;
        }
    }
}
