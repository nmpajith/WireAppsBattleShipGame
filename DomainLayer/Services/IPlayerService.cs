using DomainLayer.Enums;
using DomainLayer.Models.Game;
using DomainLayer.Models.Panels;
using DomainLayer.Models.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Services
{
    public interface IPlayerService
    {
        public void PlaceShips(Player player);
        public void PlayRound(Player player, Player oppositionPlayer, Coordinates coordinates);
        public Coordinates GetCoordinatesForAutoFire(Player player);
    }
}
