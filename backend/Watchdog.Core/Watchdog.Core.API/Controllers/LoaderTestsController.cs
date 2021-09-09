using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.LoaderTest;
using Watchdog.Core.Common.DTO.LoaderTest.Analytics;
using Watchdog.Core.Common.DTO.LoaderTest.Result;
using Watchdog.Core.Common.DTO.LoaderTest.Test;
using ILogger = Serilog.ILogger;

namespace Watchdog.Core.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LoaderTestsController : ControllerBase
    {
        private readonly ILoaderTestService _loaderTestService;
        private readonly ILogger<LoaderTestsController> _logger;

        public LoaderTestsController(ILoaderTestService loaderTestService, ILogger<LoaderTestsController> logger)
        {
            _loaderTestService = loaderTestService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<LoaderTestDto>> AddNewLoaderTest(
            [FromQuery] bool start,
            [FromBody] NewLoaderTestDto dto)
        {
            var test = await _loaderTestService.AddNewLoaderTestAsync(dto, start);
            return Ok(test);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LoaderTestDto>> GetLoaderTestById(int id)
        {
            var test = await _loaderTestService.GetLoaderTestById(id);
            return Ok(test);
        }

        [HttpGet("organization/{organizationId:int}")]
        public async Task<ActionResult<ICollection<LoaderTestDto>>> GetLoaderTestsByOrganizationId(int organizationId)
        {
            var tests = await _loaderTestService.GetLoaderTestsByOrganizationIdAsync(organizationId);
            return Ok(tests);
        }

        [HttpPut]
        public async Task<ActionResult<LoaderTestDto>> UpdateLoaderTest(
            [FromQuery] bool start,
            [FromBody] UpdateLoaderTestDto dto)
        {
            var test = await _loaderTestService.UpdateLoaderTestAsync(dto, start);
            return Ok(test);
        }

        [HttpGet("{testId:int}/resultsAnalytics")]
        public async Task<ActionResult<ICollection<LoaderTestAnalyticsDto>>> GetLoaderTestResultsAnalyticsById(
            int testId)
        {
            var tests = await _loaderTestService.GetLoaderTestResultsAnalyticsByTestIdAsync(testId);
            return Ok(tests);
        }

        [HttpGet("request/{requestId:int}/resultAnalytics")]
        public async Task<ActionResult<ICollection<LoaderTestAnalyticsDto>>> GetLoaderTestResultsAnalyticsByRequestId(
            int requestId)
        {
            var tests = await _loaderTestService.GetLoaderTestResultsAnalyticsByRequestIdAsync(requestId);
            return Ok(tests);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<LoaderTestDto>> DeleteLoaderTestById(int id)
        {
            await _loaderTestService.DeleteLoaderTestByIdAsync(id);
            _logger.LogInformation($"All tiles from Dashboard: ID = {id} has been removed.");
            return NoContent();
        }
    }
}