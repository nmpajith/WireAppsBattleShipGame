using AutoMapper;
using DomainLayer.Models.Game;
using DomainLayer.Models.Panels;
using DomainLayer.Models.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WireAppsBattleShipGame.DataTranferObjects;

namespace WireAppsBattleShipGame.Mapping
{
    public class ModelToDtoProfile:Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<Coordinates, CoordinatesDto>();
            CreateMap<Panel, PanelDto>();
            CreateMap<GamePanel, GamePanelDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<Ship, ShipDto>();
            CreateMap<Game, GameDto>();
        }
    }
}
