using AutoMapper;
using Watchdog.Core.Common.DTO.Tile;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class TileProfile : Profile
    {
        public TileProfile()
        {
            CreateMap<Tile, TileDto>();
            CreateMap<TileDto, Tile>();
            CreateMap<NewTileDto, Tile>();
            CreateMap<UpdateTileDto, Tile>();

        }
    }
}