using DomainLayer.Enums;
using DomainLayer.Models.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Game
{
    public interface IRealPlayer
    {
        public List<Panel> GetAlreadyHitPanels();
        public List<Panel> GetNeighbors(Coordinates coordinates, HitDirection hitDirection);
        public List<Coordinates> GetEmptyRandomHittablePanels();
    }
}
