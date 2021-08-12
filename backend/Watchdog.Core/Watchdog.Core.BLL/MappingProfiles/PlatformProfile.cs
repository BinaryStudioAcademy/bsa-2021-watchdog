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
            CreateMap<PlatformTypes, PlatformTypesDto>()
                .ForMember(p => p.IsBrowser, conf => conf.MapFrom(p => p.HasFlag(PlatformTypes.Browser)))
                .ForMember(p => p.IsDesktop, conf => conf.MapFrom(p => p.HasFlag(PlatformTypes.Desktop)))
                .ForMember(p => p.IsMobile, conf => conf.MapFrom(p => p.HasFlag(PlatformTypes.Mobile)))
                .ForMember(p => p.IsServer, conf => conf.MapFrom(p => p.HasFlag(PlatformTypes.Server)));
        }
    }
}
