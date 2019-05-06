using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NBAInfo.Domain.Coach
{
    public class Coach : Entity
    {
        //Define a constructor so your domain will go through when go to database, and when being created via factory.
        
        public Coach(string name, int team_id, int lastPlayoffAppearance, bool wonChampionship, int championships)
        {
            Name = name;
            Team_Id = team_id;
            LastPlayoffAppearance = lastPlayoffAppearance;
            WonChampionship = wonChampionship;
            Championships = championships;
        }

        public Coach() : base() { }

        public string Name { get; set; }
        public int Team_Id { get; set; }
        public int LastPlayoffAppearance { get; set; }
        public bool WonChampionship { get; set; }
        public int Championships { get; set; }
    }
}
