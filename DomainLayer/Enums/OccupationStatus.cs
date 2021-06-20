using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    [Flags]
    public enum OccupationStatus : short
    {
        [Description("-")]
        Empty = 0b_0000_0001,

        [Description("B")]
        Battleship = 0b_0000_0010,

        [Description("D")]
        Destroyer = 0b_0000_0100,

        [Description("X")]
        Hit = 0b_0000_1000,

        [Description("M")]
        Miss = 0b_0001_0000,

        [Description("S")]
        Sunk = 0b_0010_0000,

        IsHittable = Empty | Battleship | Destroyer,

        IsOccupied = Battleship | Destroyer
    }
}
