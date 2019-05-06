using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NBAInfo.Data.Database;
using NBAInfo.Domain.Coach;

namespace NBAInfo.Data.Seeds
{
    public static class EnsureCoachData
    {
        public static void Seed(NBAInfoContext context)
        {
            if(context.Coaches.FirstOrDefault() == null)
            {
                Coach newCoach1 = new Coach("Brad Stevens", 3, 2018, false, 0);
                Coach newCoach2 = new Coach("Luke Walton", 2, 2017, true, 1);
                Coach newCoach3 = new Coach("Alvin Gentry", 1, 2018, false, 0);
                context.Coaches.Add(newCoach3);
                context.Coaches.Add(newCoach2);
                context.Coaches.Add(newCoach1);
                context.SaveChanges();
            }
            return;
        }
    }
}
