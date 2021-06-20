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
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<CoordinatesDto, Coordinates>();
            CreateMap<PanelDto, Panel>();
            CreateMap<GamePanelDto, GamePanel>();
            CreateMap<PlayerDto, Player>();
            CreateMap<PlayerDto, RealPlayer>();
            CreateMap<PlayerDto, AutoPlayer>();
            CreateMap<ShipDto, Ship>();
            CreateMap<GameDto, Game>().
                ForMember(src => src.AutoPlayer, opt => opt.MapFrom(src => src.AutoPlayer)).
                ForMember(src => src.RealPlayer, opt => opt.MapFrom(src => src.RealPlayer)).
                ForMember(src => src.ManualShotCoordinates, opt => opt.MapFrom(src => src.ManualShotCoordinates));
        }
    }
}
