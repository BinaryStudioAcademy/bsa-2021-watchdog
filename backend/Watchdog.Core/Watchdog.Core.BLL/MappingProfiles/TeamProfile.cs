using AutoMapper;
using Watchdog.Core.Common.DTO.Team;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, Team>();

            CreateMap<Team, TeamOptionDto>();

            CreateMap<NewTeamDto, Team>();
            CreateMap<UpdateTeamDto, Team>();
        }
    }
}
