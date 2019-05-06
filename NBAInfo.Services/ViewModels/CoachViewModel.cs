using System;
using System.Collections.Generic;
using System.Text;

namespace NBAInfo.Services.ViewModels
{
    public class CoachViewModel
    {
        //Define properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public int LastPlayoffAppearance { get; set; }
        public bool WonChampionship { get; set; }
        public int Championships { get; set; }
    }
}
