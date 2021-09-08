using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.Enums.Tiles;
using Watchdog.Models.Shared.Analytics;

namespace Watchdog.Core.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }
        
        [HttpPost("requestsInfo")]
        public async Task<ActionResult<ResponseInfo>> GetTopResponsesInfoAsync(string[] appKeys,  [FromQuery] TileDateRangeType dateRangeType, [FromQuery] int count)
        {
            var responsesInfo = await _analyticsService.GetResponsesInfo(appKeys, dateRangeType, count);
            return Ok(responsesInfo);
        }
    }
}