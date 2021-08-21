using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IIssueService
    {
        Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync();
        Task UpdateAssigneeAsync(UpdateAssigneeDto assigneeDto);
        Task<IssueMessage> GetIssueMessageByIdAsync(string issueId);
        Task<ICollection<IssueMessage>> GetIssuesMessagesByParentIdAsync(string parentIssueId);
    }
}