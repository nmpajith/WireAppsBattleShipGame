using DomainLayer.Enums;
using DomainLayer.Models.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Extentions
{
    public static class PanelExtensions
    {
        /// <summary>
        /// Return the first panel that contains given x and y coordinates
        /// </summary>
        /// <param name="panels">List of panels </param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>panel that contains given coordinates, null if not found</returns>
        public static Panel FirstOrDefault(this List<Panel> panels, int x, int y)
        {
            return panels.Where(panel => panel.Coordinates.X== x && panel.Coordinates.Y == y).FirstOrDefault();
        }

        /// <summary>
        /// Return the first panel that matches with given coordinates from the list
        /// </summary>
        /// <param name="panels"></param>
        /// <param name="coordinates">Coordites of the panel to be found</param>
        /// <returns>panel that contains given coordinates or null if not found</returns>
        public static Panel FirstOrDefault(this List<Panel> panels, Coordinates coordinates)
        {
            return panels.FirstOrDefault(panel => panel.Coordinates.Equals(coordinates));
        }

        /// <summary>
        /// Gets the common direction of list of panels
        /// </summary>
        /// <param name="panels">List of panels</param>
        /// <returns>Common direction </returns>
        public static HitDirection GetHitDirection(this List<Panel> panels)
        {
            if (panels?.Count > 1)
            {
                if (panels[0].Coordinates.X == panels[1].Coordinates.X)
                    return HitDirection.Y;
                else
                    return HitDirection.X;
            }
            return HitDirection.XY;
        }

        /// <summary>
        /// Gets range of panelswithin given list of panels belongs to given coordinate boundary
        /// </summary>
        /// <param name="panels">List of panels on which, range to be check</param>
        /// <param name="startX">starting panel's x</param>
        /// <param name="startY">starting paneln's y</param>
        /// <param name="endX">end panels's x</param>
        /// <param name="endY">end panels's y</param>
        /// <returns>List of panels within boundary</returns>
        public static List<Panel> Range(this List<Panel> panels, int startX, int startY, int endX, int endY)
        {
            return panels.Where(panel => panel.Coordinates.X >= startX
                                     && panel.Coordinates.Y >= startY
                                     && panel.Coordinates.X <= endX
                                     && panel.Coordinates.Y <= endY).ToList();
        }
    }
}
