using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WireAppsBattleShipGame.DataTranferObjects
{
    public class PanelDto
    {
        public OccupationStatus OccupationStatus { get; set; }
        public CoordinatesDto Coordinates { get; set; }
    }
}
