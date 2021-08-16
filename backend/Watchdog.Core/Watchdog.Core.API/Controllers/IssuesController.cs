using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Issue;

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
        public async Task<ActionResult<IssueDto>> GetIssueAsync(string errorMessage)
        {
            var issue  = await _issueService.GetIssueAsync(errorMessage);
            return Ok(issue);
        }
        
        [HttpGet("info")]
        public async Task<ActionResult<ICollection<IssueInfoDto>>> GetIssuesInfoAsync()
        {
            var issues  = await _issueService.GetIssuesInfoAsync();
            return Ok(issues);
        }
    }
}