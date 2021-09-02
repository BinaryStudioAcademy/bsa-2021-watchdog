using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Collector.Common.DTO.Issue;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Collector.BLL.MappingProfiles
{
    class AffectedUserProfile : Profile
    {
        public AffectedUserProfile()
        {
            CreateMap<AffectedUserDto, AffectedUser>();
        }
    }
}
