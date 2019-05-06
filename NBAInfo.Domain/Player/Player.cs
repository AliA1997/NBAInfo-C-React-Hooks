using System;
using System.Collections.Generic;
using System.Text;

namespace NBAInfo.Domain.Player
{
    public class Player : Entity
    {
        //Define a constructor that will accept argument and assign your properties to it.
        
        public Player(string name, int age, int? team_id, int lastAllstarAppearance, bool wonMVP, bool wonChampionship)
        {
            Name = name;
            Age = age;
            Team_Id = team_id;
            LastAllstarAppearance = lastAllstarAppearance;
            WonMVP = wonMVP;
            WonChampionship = wonChampionship;
        }

        public Player() : base() { }
        
        public string Name { get; set; }
        public int Age { get; set; }
        public int? Team_Id { get; set; }
        public int LastAllstarAppearance { get; set; }
        public bool WonMVP { get; set; }
        public bool WonChampionship { get; set; }
       
    }
}
