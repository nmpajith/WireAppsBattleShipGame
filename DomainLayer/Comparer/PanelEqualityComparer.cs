using DomainLayer.Models.Panels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Compareror
{
    public class PanelEqualityComparer : IEqualityComparer<Panel>
    {
        public bool Equals(Panel x, Panel y)
        {
            if (x.Coordinates.X == y.Coordinates.X && x.Coordinates.Y == y.Coordinates.Y)
                return true;
            return false;
        }

        public int GetHashCode([DisallowNull] Panel obj)
        {
            int hCode = obj.Coordinates.X ^ obj.Coordinates.Y;
            return hCode.GetHashCode();
        }
    }
}
