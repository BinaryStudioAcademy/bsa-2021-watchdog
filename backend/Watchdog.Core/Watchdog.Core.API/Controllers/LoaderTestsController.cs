using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.LoaderTest;

namespace Watchdog.Core.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LoaderTestsController : ControllerBase
    {
        private readonly ILoaderTestService _loaderTestService;

        public LoaderTestsController(ILoaderTestService loaderTestService)
        {
            _loaderTestService = loaderTestService;
        }
        [HttpPost]
        public async Task<ActionResult<LoaderTestDto>> AddNewLoaderTest(NewLoaderTestDto dto)
        {
            var test = await _loaderTestService.AddNewLoaderTestAsync(dto);
            return Ok(test);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaderTestDto>> GetLoaderTestById(int id)
        {
            var test = await _loaderTestService.GetLoaderTestById(id);
            return Ok(test);
        }
        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult<ICollection<LoaderTestDto>>> GetLoaderTestByOrganizationId(int organizationId)
        {
            var tests = await _loaderTestService.GetLoaderTestsByOrganizationIdAsync(organizationId);
            return Ok(tests);
        }
        [HttpPut]
        public async Task<ActionResult<LoaderTestDto>> UpdateLoaderTest(UpdateLoaderTestDto dto)
        {
            var test = await _loaderTestService.UpdateLoaderTestAsync(dto);
            return Ok(test);
        }
    }
}
