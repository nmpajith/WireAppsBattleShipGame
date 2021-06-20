using DomainLayer.Compareror;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Panels
{
    public class GamePanel
    {
        public List<Panel> Panels { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public GamePanel(int width, int height)
        {
            Width = width;
            Height = height;
            Panels = new List<Panel>();
            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= height; j++)
                {
                    Panels.Add(new Panel(i, j));
                }
            }
        }

        /// <summary>
        /// Sets the OccupationStatus of list of panles in GamePanel
        /// </summary>
        /// <param name="panels">List of panels to be set</param>
        /// <param name="occupationStatus">OccupationStatus to be set</param>
        public void SetPanelOcupationStatus(List<Panel> panels, OccupationStatus occupationStatus)
        {
            List<Panel> panelsList = Panels.Intersect(panels, new PanelEqualityComparer()).ToList();
            panelsList.ForEach(panel => panel.OccupationStatus = occupationStatus);
        }

        /// <summary>
        /// Get the panel in GamePanel using coordinates
        /// </summary>
        /// <param name="coordinates">validated coordinates within GamePanel</param>
        /// <returns>panel corresponds to given coordinates</returns>
        public Panel GetPanel(Coordinates coordinates)
        {
            return Panels.Find(panel => panel.Coordinates.X == coordinates.X && panel.Coordinates.Y == coordinates.Y);
        }

        /// <summary>
        /// Get all empty and randomly hittable panel coordinates
        /// </summary>
        /// <returns>List of empty and randomly hittable panels</returns>
        public List<Coordinates> GetEmptyRandomHittablePanels()
        {
            return Panels.Where(panel => ((panel.OccupationStatus & OccupationStatus.IsHittable) == panel.OccupationStatus)
            && panel.IsRandomHittable)
                .Select(panel => panel.Coordinates).ToList();
        }

        /// <summary>
        /// Get all empty  panel coordinates
        /// </summary>
        /// <returns>List of empty and randomly hittable panels</returns>
        public List<Coordinates> GetEmptyPanels()
        {
            return Panels.Where(panel => (panel.OccupationStatus & OccupationStatus.IsHittable) == panel.OccupationStatus)
                .Select(panel => panel.Coordinates).ToList();
        }
    }
}
