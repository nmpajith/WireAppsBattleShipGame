using DomainLayer.Communication;
using DomainLayer.Constants;
using DomainLayer.Models.Game;
using DomainLayer.Models.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Services
{
    public class ValidationService:IValidationService
    {
        public ValidationResponse ValidateCoordinates(GamePanel gamePanel, Coordinates coordinates)
        {
            if(coordinates.X > 0 && coordinates.Y > 0 &&
                coordinates.X <= PanelConstants.MaxWidth && coordinates.Y <= PanelConstants.MaxHeight)
            {
                if (gamePanel.GetEmptyPanels().Any(cood=>cood.X==coordinates.X&&cood.Y==coordinates.Y))
                    return new ValidationResponse();
                else
                    return new ValidationResponse($"You hit an already hit panel. Try again!");
            }
            else
                return new ValidationResponse($"Coordinates provided ({coordinates.X}, {coordinates.Y}) are not valid!");
        }

        public ValidationResponse ValidateGame(Game game)
        {
            if (game.AutoPlayer.HasLost)
            {
                return new ValidationResponse($"{game.RealPlayer.Name} has WON!. Start new game.");
            }
            else if (game.RealPlayer.HasLost)
            {
                return new ValidationResponse($"{game.AutoPlayer.Name} has WON!. Start new game.");
            }
            return new ValidationResponse();
        }

        public ValidationResponse ValidateAutoPlayer(Player player)
        {
            if (player != null)
                return new ValidationResponse();
            else
                return new ValidationResponse("AutoPlayer is Null");
        }
    }
}
