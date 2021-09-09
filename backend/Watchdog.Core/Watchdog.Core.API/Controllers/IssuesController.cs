using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.DTO.IssueSolution;
using Watchdog.Core.Common.Enums.Issues;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Core.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssuesController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpGet("{issueId:int}")]
        public async Task<ActionResult<IssueDto>> GetIssueByIdAsync(int issueId)
        {
            var issuesInfo = await _issueService.GetIssueByIdAsync(issueId);
            return Ok(issuesInfo);
        }

        [HttpGet("info/{memberId:int}")]
        public async Task<ActionResult<ICollection<IssueInfoDto>>> GetIssuesInfoAsync(int memberId, [FromQuery] IssueStatus? status, [FromQuery] int? projectId)
        {
            var issuesInfo = await _issueService.GetIssuesInfoAsync(memberId, status, projectId);
            return Ok(issuesInfo);
        }

        [HttpPost("info/{memberId:int}")]
        public async Task<ActionResult> GetIssuesInfoLazyAsync(int memberId, [FromBody] FilterModel filterModel, [FromQuery] IssueStatus? status, [FromQuery] int? projectId)
        {
            var (issues, totalRecord) = await _issueService.GetIssuesInfoLazyAsync(memberId, filterModel, status, projectId);
            return Ok(new { Collection = issues, TotalRecords = totalRecord });
        }

        [HttpPost("topActiveIssues")]
        public async Task<ActionResult<ICollection<IssueInfoDto>>> GetTopActiveIssues(TopActiveIssuesFilter filter)
        {
            var issuesInfo = await _issueService.GetTopActiveIssuesAsync(filter);
            return Ok(issuesInfo);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAssignee(UpdateAssigneeDto assigneeDto)
        {
            await _issueService.UpdateAssigneeAsync(assigneeDto);
            return Ok();
        }

        [HttpGet("issueId/{issueId:int}/eventId/{eventId}")]
        public async Task<ActionResult<IssueMessage>> GetEventMessageByIdAsync(int issueId, string eventId)
        {
            var issueMessage = await _issueService.GetEventMessageByIdAsync(issueId, eventId);
            return Ok(issueMessage);
        }

        [HttpGet("messagesByParent/{id:int}")]
        public async Task<ActionResult<IssueMessage>> GetEventMessagesByIssueIdAsync(int id)
        {
            var issueMessages = await _issueService.GetEventMessagesByIssueIdAsync(id);
            return Ok(issueMessages);
        }

        [HttpPost("messagesByParent/{id:int}")]
        public async Task<ActionResult> GetEventMessagesByIssueIdLazyAsync(int id, [FromBody] FilterModel filterModel)
        {
            var (issueMessages, totalRecords) = await _issueService.GetEventMessagesByIssueIdLazyAsync(id, filterModel);
            return Ok(new { Collection = issueMessages, TotalRecords = totalRecords });
        }

        [HttpGet("messages")]
        public async Task<ActionResult<ICollection<IssueMessageDto>>> GetAllIssueMessagesAsync()
        {
            var issueMessages = await _issueService.GetAllIssueMessagesAsync();
            return Ok(issueMessages);
        }

        [HttpGet("messages/application/{applicationId:int}")]
        public async Task<ActionResult<ICollection<IssueMessageDto>>> GetAllIssueMessagesByApplicationIdAsync(
            int applicationId)
        {
            var issueMessages = await _issueService.GetAllIssueMessagesByApplicationIdAsync(applicationId);
            return Ok(issueMessages);
        }

        [AllowAnonymous]
        [HttpGet("getIssueSolution/issueId/{issueId}")]
        public async Task<ActionResult<IssueItemSolutionDto>> GetIssueSolutionLinkByIssueIdAsync(int issueId)
        {
            var issueSolution = await _issueService.GetIssueSolutionByIssueIdAsync(issueId);
            return Ok(issueSolution);
        }

        [HttpPost("messages/application/{applicationId:int}/filterByStatusesAndDate")]
        public async Task<ActionResult<ICollection<IssueMessageDto>>> GetAllIssueMessagesByApplicationIdAsync(
            int applicationId, [FromBody] IssueStatusesByDateRangeFilter filter)
        {
            var issueMessages =
                await _issueService.GetAllIssueMessagesByApplicationIdAsync(applicationId, filter);
            return Ok(issueMessages);
        }

        [HttpPost("messages/application/{applicationId:int}/filterByStatusesAndDateCount")]
        public async Task<ActionResult<int>> GetFilteredIssueCountByStatusesAndDateRangeByApplicationIdAsync(
            int applicationId, [FromBody] IssueStatusesByDateRangeFilter filter)
        {
            var issueMessages = await _issueService.GetFilteredIssueCountByStatusesAndDateRangeByApplicationIdAsync(applicationId, filter);
            return Ok(issueMessages);
        }

        [HttpPut("updateStatus")]
        public async Task<ActionResult> UpdateIssueStatusAsync(UpdateIssueStatusDto issueStatusDto)
        {
            await _issueService.UpdateIssueStatusAsync(issueStatusDto);
            return Ok();
        }

        [HttpGet("info/{memberId:int}/countByStatuses")]
        public async Task<ActionResult<CountOfIssuesByStatusDto>> GetIssuesInfoCountByStatuses(int memberId)
        {
            var issuesCount = await _issueService.GetCountOfIssuesByStatuses(memberId);
            return Ok(issuesCount);
        }
    }
}
