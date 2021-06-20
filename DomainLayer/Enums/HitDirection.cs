using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    [Flags]
    public enum HitDirection : byte
    {
        X = 0b_0001,
        Y = 0b_0010,
        XY = 0b_0100
    }
}
