using System;
using System.Collections.Generic;
using System.Text;

namespace NBAInfo.Domain.Team
{
    public class Team : Entity
    {
        //Define a constructor that will be named same as database fields, and assign your properties to your arguments in your constructor.
        //Will be used by factory.
        public Team(string name, string city, int bestPlayerId, string bestPlayerOfAllTime, int lastPlayoffAppearance, int championships, int lastChampionship)
        {
            Name = name;
            City = city;
            BestPlayerId = bestPlayerId;
            BestPlayerOfAllTime = bestPlayerOfAllTime;
            LastPlayoffAppearance = lastPlayoffAppearance;
            Championships = championships;
            LastChampionship = lastChampionship;
        }

        public Team() : base() { }
    

        public string Name { get; set; }
        public string City { get; set; }
        public int BestPlayerId { get; set; }
        public string BestPlayerOfAllTime { get; set; }
        public int LastPlayoffAppearance { get; set; }
        public int Championships { get; set; }
        public int LastChampionship { get; set; }
    }
}
