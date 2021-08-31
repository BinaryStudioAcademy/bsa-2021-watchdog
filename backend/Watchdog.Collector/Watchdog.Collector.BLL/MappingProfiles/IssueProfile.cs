using AutoMapper;
using Watchdog.Common.Messages;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Collector.BLL.MappingProfiles
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<WatchdogMessage, IssueMessage>()
                .ForMember(dest => dest.IssueDetails, opt => opt.MapFrom(src => src.Details));

            CreateMap<WatchdogMessageDetails, IssueMessageDetails>()
                .ForMember(dest => dest.ErrorMessage, opt => opt.MapFrom(src => src.Error.Message))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Error.ClassName))
                .ForMember(dest => dest.StackTrace, opt => opt.MapFrom(src => src.Error.StackTrace))
                .ForMember(dest => dest.EnvironmentMessage, opt => opt.MapFrom(src => src.Environment))
                .ForMember(dest => dest.ResponseErrorMessage, opt => opt.MapFrom(src => src.Request))
                .ForPath(dest => dest.ResponseErrorMessage.Message, opt => opt.MapFrom(src => src.Response.Content))
                .ForPath(dest => dest.ResponseErrorMessage.Status, opt => opt.MapFrom(src => src.Response.StatusCode))
                .ForPath(dest => dest.ResponseErrorMessage.StatusText, opt => opt.MapFrom(src => src.Response.StatusDescription));

            CreateMap<WatchdogErrorStackTraceLineMessage, StackFrame>()
                .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.Column, opt => opt.MapFrom(src => src.ColumnNumber));

            CreateMap<WatchdogRequestMessage, HttpResponseErrorMessage>();

            CreateMap<WatchdogEnvironmentMessage, IssueEnvironment>();
        }
    }
}
