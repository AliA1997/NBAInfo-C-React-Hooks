using System;
using System.Collections.Generic;
using System.Text;

namespace NBAInfo.Services.ViewModels
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int BestPlayerId { get; set; }
        public string BestPlayerOfAllTime { get; set; }
        public int LastPlayoffAppearance { get; set; }
        public int Championships { get; set; }
        public int LastChampionship { get; set; }
    }
}
