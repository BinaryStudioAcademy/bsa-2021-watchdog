using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IIssueService
    {
        Task<int> AddIssueEventAsync(IssueMessage issueMessage);
        Task<(ICollection<IssueInfoDto>, int)> GetIssuesInfoLazyAsync(FilterModel filterModel);
        Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync();
        Task<ICollection<IssueMessage>> GetEventMessagesByIssueIdAsync(int issueId);
        Task<(ICollection<IssueMessage>, int)> GetEventMessagesByIssueIdLazyAsync(int issueId, FilterModel filterModel);
        Task<IssueMessage> GetEventMessageByIdAsync(int issueId, string eventId);
        Task UpdateAssigneeAsync(UpdateAssigneeDto assigneeDto);
    }
}