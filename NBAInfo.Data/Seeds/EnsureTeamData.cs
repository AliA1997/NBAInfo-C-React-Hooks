using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NBAInfo.Data.Database;
using NBAInfo.Domain.Team;

namespace NBAInfo.Data.Seeds
{
    public static class EnsureTeamData
    {
        public static void Seed(NBAInfoContext context)
        {
            if(context.Teams.FirstOrDefault() == null)
            {
                Team newTeam1 = new Team("Pelicans", "New Orleans", 1, "Anthony Davis", 2018, 0, 0);
                Team newTeam2 = new Team("Lakers", "Los Angeles", 2, "Magic Johnson", 2013, 16, 2010);
                Team newTeam3 = new Team("Celtics", "Boston", 3, "Bill Russell", 2018, 17, 2008);
                context.Teams.Add(newTeam1);
                context.Teams.Add(newTeam2);
                context.Teams.Add(newTeam3);
                context.SaveChanges();
            }
            return;
        }
    }
}
