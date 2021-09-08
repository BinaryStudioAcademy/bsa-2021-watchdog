using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Models.Shared.Analytics;

namespace Watchdog.Collector.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IElasticWriteService _elasticService;

        public AnalyticsController(IElasticWriteService elasticService)
        {
            _elasticService = elasticService;
        }
        
        [HttpPost("countriesInfo")]
        public async Task<IActionResult> AddProjectCountryInfoAsync(CountryInfo countryInfo)
        {
            await _elasticService.AddProjectCountryInfoAsync(countryInfo);
            return Ok();
        }
    }
}