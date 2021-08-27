using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssuesController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpGet("info/{memberId:int}")]
        public async Task<ActionResult<ICollection<IssueInfoDto>>> GetIssuesInfoAsync(int memberId)
        {
            var issuesInfo = await _issueService.GetIssuesInfoAsync(memberId);
            return Ok(issuesInfo);
        }

        [HttpPost("info/{memberId:int}")]
        public async Task<ActionResult> GetIssuesInfoLazyAsync(int memberId, [FromBody] FilterModel filterModel)
        {
            var (issues, totalRecord) = await _issueService.GetIssuesInfoLazyAsync(memberId, filterModel);
            return Ok(new { Collection = issues, TotalRecords = totalRecord });
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

        [HttpGet("messagesByParent/{id}")]
        public async Task<ActionResult<IssueMessage>> GetEventMessagesByIssueIdAsync(int id)
        {
            var issueMessages = await _issueService.GetEventMessagesByIssueIdAsync(id);
            return Ok(issueMessages);
        }

        [HttpPost("messagesByParent/{id}")]
        public async Task<ActionResult> GetEventMessagesByIssueIdLazyAsync(int id, [FromBody] FilterModel filterModel)
        {
            var (issueMessages, totalRecords) = await _issueService.GetEventMessagesByIssueIdLazyAsync(id, filterModel);
            return Ok(new { Collection = issueMessages, TotalRecords = totalRecords });
        }

        [HttpGet("messages")]
        public async Task<ActionResult<ICollection<IssueMessageDto>>> GetAllIssueMessages()
        {
            var issueMessages = await _issueService.GetAllIssueMessages();
            return Ok(issueMessages);
        }

        [HttpGet("messages/application/{applicationId:int}")]
        public async Task<ActionResult<ICollection<IssueMessageDto>>> GetAllIssueMessages(int applicationId)
        {
            var issueMessages = await _issueService.GetAllIssueMessagesByApplicationIdAsync(applicationId);
            return Ok(issueMessages);
        }


    }
}