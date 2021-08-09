using AutoMapper;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Application, ApplicationDto>();
            CreateMap<NewApplicationDto, Application>();
        }
    }
}
