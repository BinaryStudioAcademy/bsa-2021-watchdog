using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Watchdog.Core.Common.DTO.Members;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class MemberProfiles : Profile
    {
        public MemberProfiles()
        {
            CreateMap<Member, MemberDto>()
                .ForMember(m => m.FullName, conf => conf.MapFrom(m => m.User.FirstName + " " + m.User.LastName))
                .ForMember(m=> m.Email, conf => conf.MapFrom(m=> m.User.Email));
            CreateMap<NewMemberDto, Member>();
            CreateMap<UpdateMemberDto, Member>();
        }
    }
}
