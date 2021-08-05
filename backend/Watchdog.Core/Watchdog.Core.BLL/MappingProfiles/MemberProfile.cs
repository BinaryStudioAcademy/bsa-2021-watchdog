using AutoMapper;
using Watchdog.Core.Common.DTO.Members;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberDto>();
            CreateMap<NewMemberDto, Member>();
            CreateMap<UpdateMemberDto, Member>();
        }
    }
}