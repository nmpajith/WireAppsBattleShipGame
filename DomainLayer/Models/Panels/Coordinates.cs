using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Panels
{
    /// <summary>
    /// Represents the application's grid coordinate system on the game panel.
    /// </summary>
    public sealed class Coordinates:IEquatable<Coordinates>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y) => (X, Y) = (x, y);

        public bool Equals(Coordinates other)
        {
            if (other == null)
                return false;
            return X == other.X && Y == other.Y;
        }

        //Overridding - System.Object.Equals 
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Coordinates coordinatesObj = obj as Coordinates;
            if (coordinatesObj == null)
            {
                return false;
            }
            else
            {
                return this.Equals(coordinatesObj);
            }
        }

        //Overridding - System.Object.GetHashCode 
        public override int GetHashCode()
        {
            int hCode = X ^ Y;
            return hCode.GetHashCode();
        }
    }
}
