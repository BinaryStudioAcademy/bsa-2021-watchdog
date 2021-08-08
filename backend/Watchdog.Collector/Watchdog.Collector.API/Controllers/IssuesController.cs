using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Watchdog.Collector.BLL.Entities;
using Watchdog.Collector.BLL.Services.Abstract;

namespace Watchdog.Collector.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IElasticWriteService _elasticService;
        
        public IssuesController(IElasticWriteService elasticService)
        {
            _elasticService = elasticService;
        }
            
        [HttpPost]
        public async Task<IActionResult> AddNewIssue(IssueMessage message)
        {
            await _elasticService.AddIssueAsync(message);
            return Ok();
        }
    }
}