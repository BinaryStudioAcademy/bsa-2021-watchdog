using AutoMapper;
using System.Linq;
using Watchdog.Core.Common.DTO.Members;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberDto>()
                .ForMember(m => m.Teams, conf => conf.MapFrom(m => m.TeamMembers.Select(tm => tm.Team)));
            CreateMap<NewMemberDto, Member>();
            CreateMap<UpdateMemberDto, Member>();
        }
    }
}