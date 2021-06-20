using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WireAppsBattleShipGame.DataTranferObjects
{
    public class GameDto
    {
        public PlayerDto RealPlayer { get; set; }
        public PlayerDto AutoPlayer { get; set; }
        public CoordinatesDto ManualShotCoordinates { get; set; }
    }
}
