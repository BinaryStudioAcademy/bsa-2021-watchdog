using AutoMapper;
using Watchdog.Core.Common.DTO.Dashboard;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public sealed class DashboardProfile : Profile
    {
        public DashboardProfile()
        {
            CreateMap<Dashboard, DashboardDto>();

            CreateMap<DashboardDto, Dashboard>();
            CreateMap<NewDashboardDto, Dashboard>();
        }
    }
}
