using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.DTO.IssueSolution;
using Watchdog.Core.Common.Enums.Issues;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IIssueService
    {
        Task<int> AddIssueEventAsync(IssueMessage issueMessage);
        Task<(ICollection<IssueLazyLoadDto>, int)> GetIssuesInfoLazyAsync(int memberId, FilterModel filterModel, IssueStatus? status, int? appId);
        Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync(int memberId, IssueStatus? status, int? appId);
        Task<ICollection<IssueMessage>> GetEventMessagesByIssueIdAsync(int issueId);
        Task<(ICollection<IssueMessage>, int)> GetEventMessagesByIssueIdLazyAsync(int issueId, FilterModel filterModel);
        Task<IssueMessage> GetEventMessageByIdAsync(int issueId, string eventId);
        Task UpdateAssigneeAsync(UpdateAssigneeDto assigneeDto);
        Task<ICollection<IssueMessageDto>> GetAllIssueMessagesAsync();
        Task<ICollection<IssueMessageDto>> GetAllIssueMessagesByApplicationIdAsync(int applicationId);
        Task<ICollection<IssueMessageDto>> GetAllIssueMessagesByApplicationIdAsync(int applicationId, IssueStatusesByDateRangeFilter filter);
        Task<int> GetFilteredIssueCountByStatusesAndDateRangeByApplicationIdAsync(int applicationId, IssueStatusesByDateRangeFilter filter);
        Task UpdateIssueStatusAsync(UpdateIssueStatusDto issueStatusDto);
        Task<IssueDto> GetIssueByIdAsync(int issueId);
        Task<IssueItemSolutionDto> GetIssueSolutionByIssueIdAsync(int issueId);
        Task<CountOfIssuesByStatusDto> GetCountOfIssuesByStatuses(int memberId);
        Task<ICollection<IssueInfoDto>> GetTopActiveIssuesAsync(TopActiveIssuesFilter filter);
    }
}