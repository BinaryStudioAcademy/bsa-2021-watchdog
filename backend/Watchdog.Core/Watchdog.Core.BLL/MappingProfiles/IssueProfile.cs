using AutoMapper;
using Watchdog.Core.Common.Models.Issue;
using Watchdog.Core.DAL.Entities;
using Issue = Watchdog.Core.DAL.Entities.Issue;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<IssueMessage, EventMessage>()
                .ForMember(
                    dest => dest.EventId, 
                    opt => opt.MapFrom(scr => scr.Id));

            CreateMap<IssueMessage, Issue>()
                .ForMember(
                    dest => dest.ErrorClass,
                    opt => opt.MapFrom(src => src.IssueDetails.ClassName))
                .ForMember(dest => dest.ErrorMessage,
                    opt => opt.MapFrom(scr => scr.IssueDetails.ErrorMessage));
        }
    }
}