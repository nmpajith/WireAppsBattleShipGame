using DomainLayer.Enums;
using DomainLayer.Extentions;
using DomainLayer.Models.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Game
{
    public class RealPlayer : Player, IRealPlayer
    {
        public RealPlayer(string name) : base(name) { }

        /// <summary>
        /// Get all neighors of given coordinates in given direction
        /// </summary>
        /// <param name="coordinates">coordinates on which neighbors has to be found</param>
        /// <param name="hitDirection">Direction in which neighbors to be found</param>
        /// <returns>All neighbors found</returns>
        public List<Panel> GetNeighbors(Coordinates coordinates, HitDirection hitDirection)
        {
            int x = coordinates.X;
            int y = coordinates.Y;
            List<Panel> panels = new List<Panel>();
            if (y > 1 && (hitDirection == HitDirection.XY || hitDirection == HitDirection.Y))
            {
                panels.Add(GamePanel.Panels.FirstOrDefault(x, y - 1));
            }
            if (x > 1 && (hitDirection == HitDirection.XY || hitDirection == HitDirection.X))
            {
                panels.Add(GamePanel.Panels.FirstOrDefault(x - 1, y));
            }
            if (x < 10 && (hitDirection == HitDirection.XY || hitDirection == HitDirection.X))
            {
                panels.Add(GamePanel.Panels.FirstOrDefault(x + 1, y));
            }
            if (y < 10 && (hitDirection == HitDirection.XY || hitDirection == HitDirection.Y))
            {
                panels.Add(GamePanel.Panels.FirstOrDefault(x, y + 1));
            }
            return panels;
        }

        /// <summary>
        /// Gets already hit panels from first ship found with already hit panels
        /// </summary>
        /// <returns>List of panels already hit</returns>
        public List<Panel> GetAlreadyHitPanels()
        {
            foreach (var ship in Ships)
            {
                var panels = ship.GetAlreadyHitPanels();
                if (panels?.Count() > 0)
                {
                    return panels;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets empty and randmly available panels from palyers game panel
        /// </summary>
        /// <returns>List of randomly availble panel coordinates</returns>
        public List<Coordinates> GetEmptyRandomHittablePanels()
        {
            return GamePanel.GetEmptyRandomHittablePanels();
        }
    }
}
