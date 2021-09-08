using AutoMapper;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.DTO.IssueSolution;
using Watchdog.Core.DAL.Entities;
using Watchdog.Models.Shared.Emailer.TemplateData;
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
                    opt => opt.MapFrom(scr => scr.OccurredOn))
                .ForMember(dest => dest.AffectedUserIdentifier, opt => opt.MapFrom(scr => scr.User.Identifier));

            CreateMap<EventMessage, IssueMessageDto>();
            CreateMap<Issue, IssueDto>();

            CreateMap<IssueItemSolution, IssueItemSolutionDto>();
            CreateMap<IssueAnswer, IssueAnswerDto>();

            CreateMap<IssueMessage, IssueTemplate>();
            CreateMap<IssueMessageDetails, IssueDetailsTemplate>();
            CreateMap<StackFrame, StackFrameTemplate>();
            CreateMap<IssueEnvironment, IssueEnvironmentTemplate>();
            CreateMap<HttpResponseErrorMessage, ResponseErrorMessageTemplate>();
        }
    }
}