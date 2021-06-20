using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Game
{
    public class AutoPlayer : Player, IAutoPlayer
    {
        public AutoPlayer(string name) : base(name) { }
    }
}
