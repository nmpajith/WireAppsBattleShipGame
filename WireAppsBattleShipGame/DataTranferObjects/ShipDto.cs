using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WireAppsBattleShipGame.DataTranferObjects
{
    public class ShipDto
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Hits { get; set; }
        public OccupationStatus OccupationStatus { get; set; }
        public List<PanelDto> Panels { get; set; }
    }
}
