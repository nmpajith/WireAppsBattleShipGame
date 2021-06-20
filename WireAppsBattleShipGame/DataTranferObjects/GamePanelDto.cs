using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WireAppsBattleShipGame.DataTranferObjects
{
    public class GamePanelDto
    {
        public List<PanelDto> Panels { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}
