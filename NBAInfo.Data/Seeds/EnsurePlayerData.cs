using NBAInfo.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NBAInfo.Domain.Player;

namespace NBAInfo.Data.Seeds
{
    public static class EnsurePlayerData
    {
        public static void Seed(NBAInfoContext context)
        {
            if(context.Players.FirstOrDefault() == null)
            {
                Player newPlayer1 = new Player("Anthony Davis", 25, 1, 2018, false, false);
                Player newPlayer2 = new Player("Lebron James", 33, 2, 2018, true, true);
                Player newPlayer3 = new Player("Kyrie Irving", 26, 3, 2018, false, true);
                context.Players.Add(newPlayer1);
                context.Players.Add(newPlayer2);
                context.Players.Add(newPlayer3);
                context.SaveChanges();
            }
        }
    }
}
