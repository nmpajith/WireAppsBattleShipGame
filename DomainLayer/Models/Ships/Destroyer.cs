using DomainLayer.Models.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Ships
{
    public class Destroyer:Ship
    {
        public Destroyer():base(100)
        {
            Name = "Destroyer";
            Width = 4;
            OccupationStatus = Enums.OccupationStatus.Destroyer;
            Panels = new List<Panel>();
        }
    }
}
