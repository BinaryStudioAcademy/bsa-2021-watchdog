using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Platform;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    class PlatformProfile: Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformDto>()
                .ForMember(p => p.PlatformTypes,
                conf => conf.MapFrom(p => p.PlatformTypes.Select(p => p.Name)));
        }
    }
}
