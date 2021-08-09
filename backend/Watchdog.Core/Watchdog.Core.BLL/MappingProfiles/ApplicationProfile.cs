using AutoMapper;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.DTO.ApplicationTeam;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public sealed class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Application, ApplicationDto>();
            CreateMap<ApplicationDto, Application>();

            CreateMap<ApplicationTeam, ApplicationTeamDto>();
            CreateMap<ApplicationTeamDto, ApplicationTeam>();
            CreateMap<NewApplicationTeamDto, ApplicationTeam>();
        }
    }
}
