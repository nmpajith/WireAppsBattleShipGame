using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WireAppsBattleShipGame.DataTranferObjects
{
    public class PlayerDto
    {
        public string Name { get; set; }
        public GamePanelDto GamePanel { get; set; }
        public List<ShipDto> Ships { get; set; }
        public string HitResult { get; set; }
        public int Points { get; set; }
    }
}
