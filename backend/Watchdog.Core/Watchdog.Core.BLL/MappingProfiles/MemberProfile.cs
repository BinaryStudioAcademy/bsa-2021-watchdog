using AutoMapper;
using System.Linq;
using Watchdog.Core.Common.DTO.Members;
using Watchdog.Core.DAL.Entities;
using Watchdog.Models.Shared.Emailer;
using Watchdog.Models.Shared.Emailer.TemplateData;

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

            CreateMap<MemberDto, MemberTemplate>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(scr => scr.UserFirstName));
            CreateMap<MemberDto, Recipient>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(scr => scr.UserFirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(scr => scr.UserLastName))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(scr => scr.UserEmail));
        }
    }
}