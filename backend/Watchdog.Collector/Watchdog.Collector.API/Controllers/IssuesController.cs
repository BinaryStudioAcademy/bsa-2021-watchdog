using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.DTO.Issue;
using Watchdog.Common.Messages;
using Watchdog.Models.Shared.Analytics;

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
        
        [HttpPost("countriesInfo")]
        public async Task<IActionResult> AddProjectCountryInfoAsync(CountryInfo countryInfo)
        {
            await _elasticService.AddProjectCountryInfoAsync(countryInfo);
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNewIssue(IssueMessageDto message)
        {
            await _elasticService.AddIssueMessageAsync(message);
            return Ok();
        }

        [HttpPost("client")]
        public async Task<IActionResult> AddNewIssue(WatchdogMessage message)
        {
            await _elasticService.AddIssueAsync(message);
            return Ok();
        }
    }
}