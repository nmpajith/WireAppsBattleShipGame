using DomainLayer.Communication;
using DomainLayer.Models.Game;
using DomainLayer.Models.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Services
{
    public interface IValidationService
    {
        public ValidationResponse ValidateGame(Game game);
        public ValidationResponse ValidateCoordinates(GamePanel gamePanel, Coordinates coordinates);
        public ValidationResponse ValidateAutoPlayer(Player player);
    }
}
