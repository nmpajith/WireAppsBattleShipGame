using DomainLayer.Enums;
using DomainLayer.Extentions;
using DomainLayer.Models.Panels;
using DomainLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Game
{
    public class Game
    {
        public RealPlayer RealPlayer { get; set; }
        public AutoPlayer AutoPlayer { get; set; }
        public Coordinates ManualShotCoordinates { get; set; }

        public Game()
        {            
            RealPlayer = new RealPlayer("Ajith");
            AutoPlayer = new AutoPlayer("Auto Player");
        }        
    }
}

