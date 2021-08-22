using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IIssueService
    {
        Task<int> AddIssueEvent(IssueMessage issueMessage);
        Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync();
        Task<ICollection<IssueMessage>> GetEventMessagesByIssueIdAsync(int issueId);
        Task<IssueMessage> GetEventMessageByIdAsync(string eventId);
        Task UpdateAssigneeAsync(UpdateAssigneeDto assigneeDto);
    }
}