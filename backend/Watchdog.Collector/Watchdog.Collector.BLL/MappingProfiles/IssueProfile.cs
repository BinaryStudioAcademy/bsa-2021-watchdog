using AutoMapper;
using Watchdog.Collector.Common.Models;
using Watchdog.Common.Messages;

namespace Watchdog.Collector.BLL.MappingProfiles
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<WatchdogMessage, IssueMessage>()
                .ForMember(dest => dest.IssueDetails, opt => opt.MapFrom(src => src.Details));

            CreateMap<WatchdogMessageDetails, IssueMessageDetails>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Request.Url))
                .ForMember(dest => dest.ErrorMessage, opt => opt.MapFrom(src => src.Error.Message))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Error.ClassName))
                .ForMember(dest => dest.StackTrace, opt => opt.MapFrom(src => src.Error.StackTrace))
                .ForMember(dest => dest.ResponseErrorMessage, opt => opt.MapFrom(src => src.Response))
                .ForMember(dest => dest.EnvironmentMessage, opt => opt.MapFrom(src => src.Environment))
                .ForPath(dest => dest.ResponseErrorMessage.Url, opt => opt.MapFrom(src => src.Request.Url));

            CreateMap<WatchdogErrorStackTraceLineMessage, StackFrame>()
                .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.Column, opt => opt.MapFrom(src => src.ColumnNumber));

            CreateMap<WatchdogResponseMessage, HttpResponseErrorMessage>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.StatusCode))
                .ForMember(dest => dest.StatusText, opt => opt.MapFrom(src => src.StatusDescription));

            CreateMap<WatchdogEnvironmentMessage, IssueEnvironment>()
                .ForMember(dest => dest.Platform, opt => opt.MapFrom(src => src.Platform));
        }
    }
}
