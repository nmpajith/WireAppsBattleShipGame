using DomainLayer.Models.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Ships
{
    public class Battleship : Ship
    {
        public Battleship():base(120)
        {
            Name = "Battleship";
            Width = 5;
            OccupationStatus = Enums.OccupationStatus.Battleship;
            Panels = new List<Panel>();
        }
    }
}
