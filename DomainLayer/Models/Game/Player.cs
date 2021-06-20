using DomainLayer.Compareror;
using DomainLayer.Constants;
using DomainLayer.Enums;
using DomainLayer.Extentions;
using DomainLayer.Models.Panels;
using DomainLayer.Models.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Game
{
    public class Player
    {
        public string Name { get; set; }
        public GamePanel GamePanel { get; set; }
        public List<Ship> Ships { get; set; }
        public string HitResult { get; set; }
        public int Points { get; set; }
        public bool HasLost
        {
            get=> Ships.All(ship => ship.IsSunk);
        }

        public Player(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Destroyer(),
                new Destroyer(),
                new Battleship()
            };
            GamePanel = new GamePanel(PanelConstants.MaxWidth, PanelConstants.MaxHeight);
        } 

        /// <summary>
        /// Checks if any ship belongs to player contains given panel
        /// </summary>
        /// <param name="panel">panel to be checked</param>
        /// <returns>true if a ship contains panel</returns>
        public bool ShipsContains(Panel panel)
        {
            return Ships.Any(ship => ship.Contains(panel));
        }

        /// <summary>
        /// Checks if any ship belongs to player contains given coordinates
        /// </summary>
        /// <param name="coordinates">Coordinates of given panel</param>
        /// <returns>true if any of ships conatins given coordinates</returns>
        public bool ShipsContains(Coordinates coordinates)
        {
            return Ships.Any(ship => ship.Contains(coordinates));
        }


        /// <summary>
        /// Gets the panel in GamePanel using coordinates
        /// </summary>
        /// <param name="coordinates">Coordinates of panel where we fire a shot</param>
        /// <returns>Panel in GamePanel</returns>
        public Panel GetFiredPanel(Coordinates coordinates)
        {
            return GamePanel.GetPanel(coordinates);
        }

        /// <summary>
        /// Return the ship that contains given panel
        /// </summary>
        /// <param name="panel">panel to be within ship</param>
        /// <returns>Ship that contains given panel. Null if no ships found</returns>
        public Ship GetShipContainingPanel(Panel panel)
        {
            return Ships.FirstOrDefault(ship => ship.Panels.Contains(panel, new PanelEqualityComparer()));
        }

        /// <summary>
        /// Return the ship that contains given coordinates
        /// </summary>
        /// <param name="coordinates">Coordinates to be within ship</param>
        /// <returns>Ship that contains given coodinates. Null if no ships found</returns>
        public Ship GetShipContainingPanel(Coordinates coordinates)
        {
            return Ships.FirstOrDefault(ship => ship.Contains(coordinates));
        }
       

        /// <summary>
        /// Sets occupationstatus of panel in gamepanel
        /// </summary>
        /// <param name="coordinates">coordinates of the panel to be set</param>
        /// <param name="occupationStatus">OccupationStatus to be set</param>
        public void SetPanelStatusInGamePanel(Coordinates coordinates, OccupationStatus occupationStatus)
        {
            var panel = GamePanel.GetPanel(coordinates);
            panel.OccupationStatus = occupationStatus;
        }

        /// <summary>
        /// Places ships in gamepanel
        /// </summary>
        public void PlaceShips()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                //Select a random row/column combination, then select a random orientation.
                //If none of the proposed panels are occupied, place the ship
                //Do this for all ships

                bool isOpen = true;
                while (isOpen)
                {
                    var startY = rand.Next(1, 11);
                    var startX = rand.Next(1, 11);
                    int endX = startX, endY = startY;
                    var orientation = rand.Next(1, 101) % 2; 

                    List<int> panelNumbers = new List<int>();
                    if (orientation == 0)   // Horizontal
                        endX += ship.Width - 1;
                    else
                        endY += ship.Width - 1;

                    //Cannot place ships beyond the boundaries of the board
                    if (endX > PanelConstants.MaxWidth || endY > PanelConstants.MaxHeight)
                    {
                        isOpen = true;
                        continue;
                    }

                    //Check if specified panels are occupied
                    var affectedPanels = GamePanel.Panels.Range(startX, startY, endX, endY);
                    if (affectedPanels.Any(panel => panel.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }

                    foreach (var panel in affectedPanels)
                    {
                        panel.OccupationStatus = ship.OccupationStatus;
                    }
                    //update ship panels
                    ship.Panels = affectedPanels;
                    isOpen = false;
                }
            }
        }        
    }
}
