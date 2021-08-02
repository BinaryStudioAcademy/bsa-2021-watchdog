using AutoMapper;
using System.Linq;
using Watchdog.Core.Common.DTO.Team;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDto>()
                .ForMember(t => t.Members,
                    opt => opt.MapFrom(t => t.TeamMembers.Select(teamMember => teamMember.Member)));
            CreateMap<TeamDto, Team>();
            CreateMap<NewTeamDto, Team>();
            CreateMap<UpdateTeamDto, Team>();
        }
    }
}
