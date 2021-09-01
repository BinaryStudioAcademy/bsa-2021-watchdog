using AutoMapper;
using Watchdog.Collector.Common.DTO.Issue;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Collector.BLL.MappingProfiles
{
    public class IssueMessageProfile : Profile
    {
        public IssueMessageProfile()
        {
            CreateMap<IssueMessageDto, IssueMessage>();
        }
    }
}