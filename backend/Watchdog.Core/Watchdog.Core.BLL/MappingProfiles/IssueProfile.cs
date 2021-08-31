using AutoMapper;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.DAL.Entities;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<IssueMessage, Issue>()
                .ForMember(dest => dest.Id, 
                    opt => opt.Ignore())
                .ForMember(dest => dest.ErrorClass,
                    opt => opt.MapFrom(src => src.IssueDetails.ClassName))
                .ForMember(dest => dest.ErrorMessage,
                    opt => opt.MapFrom(scr => scr.IssueDetails.ErrorMessage));
            
            CreateMap<IssueMessage, EventMessage>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.EventId,
                    opt => opt.MapFrom(scr => scr.Id))
                .ForMember(dest => dest.OccurredOn,
                    opt => opt.MapFrom(scr => scr.OccurredOn));

            CreateMap<EventMessage, IssueMessageDto>();
        }
    }
}