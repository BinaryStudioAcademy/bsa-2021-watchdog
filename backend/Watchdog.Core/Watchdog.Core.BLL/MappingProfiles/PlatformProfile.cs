using AutoMapper;
using Watchdog.Core.Common.DTO.Platform;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformDto>();
            CreateMap<PlatformDto, Platform>();
        }
    }
}
