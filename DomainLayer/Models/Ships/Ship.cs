using DomainLayer.Compareror;
using DomainLayer.Enums;
using DomainLayer.Models.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Ships
{
    /// <summary>
    /// Base class to repesent a player's ship on their Game Panel.
    /// </summary>
    public class Ship
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Hits { get; set; }
        public readonly int PointsPerPanel;
        public OccupationStatus OccupationStatus { get; set; }
        public List<Panel> Panels { get; set; }
        public bool IsSunk => Hits >= Width;

        public Ship(int pointsPerPanel=100)
        {
            PointsPerPanel = pointsPerPanel;
        }

        /// <summary>
        /// Checks if a panel is within ship boundary
        /// </summary>
        /// <param name="panel">Panel to be check</param>
        /// <returns>True if panel is within ship'sboundary</returns>
        public bool Contains(Panel panel)
        {
            return Panels.Contains(panel, new PanelEqualityComparer());
        }

        /// <summary>
        /// Checks if given coordinates is within ship's boundary
        /// </summary>
        /// <param name="coordinates">Coordinates to be check</param>
        /// <returns>True if coordinates is within ship'sboundary</returns>
        public bool Contains(Coordinates coordinates)
        {
            return Contains(new Panel(coordinates));
        }

        /// <summary>
        /// Gets already hit panels in ship
        /// </summary>
        /// <returns>List of already hit panels</returns>
        public List<Panel> GetAlreadyHitPanels()
        {
            return Panels.Where(panel => panel.OccupationStatus == OccupationStatus.Hit).ToList();
        }

        /// <summary>
        /// Sets occupation sttaus of a ship's panel with given coordinates to the occupation status 
        /// </summary>
        /// <param name="coordinates">Coordinates of the panel to be set</param>
        /// <param name="occupationStatus">New OccupationStatus</param>
        public void SetPanelOccupationStatus(Coordinates coordinates, OccupationStatus occupationStatus)
        {
            Panels.First(panel => panel.Coordinates.Equals(coordinates)).OccupationStatus = occupationStatus;
        }
    }
}
