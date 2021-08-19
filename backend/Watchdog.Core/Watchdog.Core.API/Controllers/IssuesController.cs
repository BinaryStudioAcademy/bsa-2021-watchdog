using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet("info")]
        public async Task<ActionResult<ICollection<IssueInfoDto>>> GetIssuesInfoAsync()
        {
            var issues = await _issueService.GetIssuesInfoAsync();
            return Ok(issues);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAssignee(UpdateAssigneeDto assigneeDto)
        {
            await _issueService.UpdateAssignee(assigneeDto);
            return Ok(); 
        }

        [HttpGet("message/{id}")]
        public async Task<ActionResult<IssueMessage>> GetIssueMessageByIdAsync(string id)
        {
            var issueMessage = await _issueService.GetIssueMessageByIdAsync(id);
            return Ok(issueMessage);
        }        
        
        [HttpGet("messagesByParent/{id}")]
        public async Task<ActionResult<IssueMessage>> GetIssueMessagesByParentIdAsync(string id)
        {
            var issueMessages = await _issueService.GetIssuesMessagesByParentIdAsync(id);
            return Ok(issueMessages);
        }
    }
}