using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        
        [HttpGet]
        public async Task<ActionResult<ICollection<IssueMessage>>> GetIssuesAsync()
        {
            var issues  = await _issueService.GetIssuesAsync();
            return Ok(issues);
        }

        [HttpGet("topIssues")]
        public async Task<ActionResult<ICollection<TileIssueInfo>>> GetIssuesInfoAsync()
        {
            var issuesInfo = await _issueService.GetIssuesInfoAsync();
            return Ok(issuesInfo);
        }
    }
}