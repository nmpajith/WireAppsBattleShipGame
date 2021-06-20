using DomainLayer.Constants;
using DomainLayer.Enums;
using DomainLayer.Extentions;
using DomainLayer.Models.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Panels
{
    /// <summary>
    /// Represents a single square on the game panel.
    /// </summary>
    public class Panel
    {
        public OccupationStatus OccupationStatus { get; set; }
        public Coordinates Coordinates { get; set; }

        public Panel(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            OccupationStatus = OccupationStatus.Empty;
        }

        public Panel(Coordinates coordinates) : this(coordinates.X, coordinates.Y) { }

        /// <summary>
        /// Returns description attribute of the related enum
        /// </summary>
        public string OccupationStatusDescription => OccupationStatus.GetAttributeOfType<DescriptionAttribute>().Description;

        /// <summary>
        /// True if a ship is occupied 
        /// </summary>
        public bool IsOccupied => (OccupationStatus & OccupationStatus.IsOccupied)== OccupationStatus;

        /// <summary>
        /// Computer can fire random shots efficently by guessing minimum hit requirement
        /// </summary>
        public bool IsRandomHittable => Coordinates.X % ShipConstants.MinWidth == Coordinates.Y % ShipConstants.MinWidth;
    }
}
