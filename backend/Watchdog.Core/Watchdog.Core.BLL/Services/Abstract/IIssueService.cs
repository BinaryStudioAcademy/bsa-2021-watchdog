using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Enums.Issues;
using Watchdog.Core.Common.Models.Issue;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IIssueService
    {
        Task<int> AddIssueEventAsync(IssueMessage issueMessage);
        Task<(ICollection<IssueInfoDto>, int)> GetIssuesInfoLazyAsync(int memberId, FilterModel filterModel);
        Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync(int memberId);
        Task<ICollection<IssueMessage>> GetEventMessagesByIssueIdAsync(int issueId);
        Task<(ICollection<IssueMessage>, int)> GetEventMessagesByIssueIdLazyAsync(int issueId, FilterModel filterModel);
        Task<IssueMessage> GetEventMessageByIdAsync(int issueId, string eventId);
        Task UpdateAssigneeAsync(UpdateAssigneeDto assigneeDto);
        Task<ICollection<IssueMessageDto>> GetAllIssueMessagesAsync();
        Task<ICollection<IssueMessageDto>> GetAllIssueMessagesByApplicationIdAsync(int applicationId);
        Task<ICollection<IssueMessageDto>> GetAllIssueMessagesByApplicationIdAsync(int applicationId, IssueStatusesFilterDto statusesFilter);
        Task UpdateIssueStatusAsync(UpdateIssueStatusDto issueStatusDto);
        Task<IssueDto> GetIssueByIdAsync(int issueId);
    }
}