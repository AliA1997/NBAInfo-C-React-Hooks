using System;
using System.Collections.Generic;
using System.Text;

namespace NBAInfo.Services.ViewModels
{
    public class PlayerViewModel
    {
        //Define properites
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
        public int LastAllstarAppearance { get; set; }
        public bool WonMVP { get; set; }
        public bool WonChampionship { get; set; }
    }
}
