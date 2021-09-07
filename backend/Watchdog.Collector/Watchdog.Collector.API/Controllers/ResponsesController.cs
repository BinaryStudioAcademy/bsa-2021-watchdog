using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Models.Shared.Analytics;

namespace Watchdog.Collector.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResponsesController : ControllerBase
    {
        private readonly IElasticWriteService _elasticService;
        
        public ResponsesController(IElasticWriteService elasticService)
        {
            _elasticService = elasticService;
        }
        
        [HttpPost]
        public async Task<IActionResult> LogResponse(ResponseInfo response)
        {
            await _elasticService.LogResponse(response);
            return Ok();
        }
    }
}