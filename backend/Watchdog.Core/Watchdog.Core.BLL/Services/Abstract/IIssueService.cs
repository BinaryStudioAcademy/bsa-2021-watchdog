using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IIssueService
    {
        Task<int> AddIssueEventAsync(IssueMessage issueMessage);
        Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync(int memberId);
        Task<ICollection<IssueMessage>> GetEventMessagesByIssueIdAsync(int issueId);
        Task<IssueMessage> GetEventMessageByIdAsync(int issueId, string eventId);
        Task UpdateAssigneeAsync(UpdateAssigneeDto assigneeDto);
    }
}