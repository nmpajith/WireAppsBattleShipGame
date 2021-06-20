using DomainLayer.Constants;
using DomainLayer.Enums;
using DomainLayer.Extentions;
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
    public class PlayerService : IPlayerService
    {
        public void PlayRound(Player player,Player oppositionPlayer, Coordinates coordinates)
        {
            //check if it is a hit, if coordinates conatins within oppositions ships, its a hit
            bool isAHit = oppositionPlayer.ShipsContains(coordinates);
            if (isAHit)
            {
                oppositionPlayer.HitResult= $"Great {player.Name}, \"Its a Hit!\"";
                setShotResults(player, oppositionPlayer, coordinates, OccupationStatus.Hit);
            }
            else
            {
                setShotResults(player, oppositionPlayer, coordinates, OccupationStatus.Miss);
            }
        }

        public Coordinates GetCoordinatesForAutoFire(Player player)
        {
            if (player is RealPlayer)
            {
                IRealPlayer realPlayer = player as RealPlayer;
                //Check if player1's has already hit ship planels
                var hitPanels = realPlayer.GetAlreadyHitPanels();
                Coordinates coordinates;
                if (hitPanels != null)
                {
                    //Get ship orientation or the direction in which it is best hit
                    HitDirection hitDirection = hitPanels.GetHitDirection();
                    //Get hittable neighbors of the player
                    var hittableNeighbors = getHittableNeighbors(player, hitPanels, hitDirection);
                    Random rand = new Random(Guid.NewGuid().GetHashCode());
                    var neighborID = rand.Next(hittableNeighbors.Count);
                    coordinates = hittableNeighbors[neighborID];
                }
                else
                {
                    var randomHittable = realPlayer.GetEmptyRandomHittablePanels();
                    Random rand = new Random(Guid.NewGuid().GetHashCode());
                    var panelID = rand.Next(randomHittable.Count);
                    coordinates = randomHittable[panelID];
                }
                return coordinates;
            }
            return null;
        }

        private List<Coordinates> getHittableNeighbors(Player player,List<Panel> hitPanels, HitDirection hitDirection)
        {
            if (player is RealPlayer)
            {
                IRealPlayer realPlayer = player as RealPlayer;
                List<Panel> panels = new List<Panel>();
                foreach (var hit in hitPanels)
                {
                    panels.AddRange(realPlayer.GetNeighbors(hit.Coordinates, hitDirection));
                }
                return panels.Distinct().Where(panel => (panel.OccupationStatus & OccupationStatus.IsHittable) == panel.OccupationStatus)
                    .Select(panel => panel.Coordinates).ToList();
            }
            return null;
        }    

        public void PlaceShips(Player player)
        {
            player.PlaceShips();
        }

        private void setShotResults(Player player,Player oppositionPlayer, Coordinates coordinates, OccupationStatus occupationStatus)
        {
            if (occupationStatus == OccupationStatus.Hit)
            {
                //get the ship which belongs the fired coordinates
                var ship = oppositionPlayer.GetShipContainingPanel(coordinates);
                ship.Hits++;
                //add points
                player.Points += ship.PointsPerPanel;
                //Now set the status in Ship's struck panel
                ship.SetPanelOccupationStatus(coordinates, occupationStatus);
                //Now set the status in GamePanel's struck panel
                oppositionPlayer.SetPanelStatusInGamePanel(coordinates, occupationStatus);
                if (ship.IsSunk)
                {
                    //add adtinal 50 points for sinking a ship
                    player.Points += ShipConstants.AdditinalPointsForSinking;
                    //set all sunk ship's panles in GamePanel as sunk
                    oppositionPlayer.GamePanel.SetPanelOcupationStatus(ship.Panels, OccupationStatus.Sunk);
                    //remove sunk ship from ships list
                    oppositionPlayer.Ships.Remove(ship);
                    oppositionPlayer.HitResult=$"Well done {player.Name} You sunk my " + ship.Name + "!";
                }
            }
            else
            {
                //Its A misfire! If Player has earened points deduct points.
                oppositionPlayer.HitResult = $"Sorry {player.Name} Its a Misfire. Try again!";
                if (player.Points > 0)
                    player.Points -= ShipConstants.DeductPointsForMisfire;
                //Now set the status in GamePanel's struck panel
                oppositionPlayer.SetPanelStatusInGamePanel(coordinates, occupationStatus);
            }
        }
    }
}
