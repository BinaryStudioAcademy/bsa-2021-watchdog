using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.BLL.Services;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Sample;

namespace Watchdog.Core.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {

        private readonly ILogger<SampleController> _logger;
        private readonly ISampleService _sampleService;
        private readonly QueueService _queueService;
        private readonly IEmailSendService _emailSendService;

        public SampleController(ILogger<SampleController> logger,
                                ISampleService sampleService,
                                QueueService queueService,
                                IEmailSendService emailSendService)
        {
            _logger = logger;
            _sampleService = sampleService;
            _queueService = queueService;
            _emailSendService = emailSendService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<SampleDto>>> GetAllAsync()
        {
            var samples = await _sampleService.GetAllSamplesAsync();
            return Ok(samples);
        }

        [HttpGet("{sampleId}")]
        public async Task<ActionResult<SampleDto>> GetAsync(int sampleId)
        {
            var sample = await _sampleService.GetSampleAsync(sampleId);
            return Ok(sample);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ICollection<SampleDto>>> GetByUserAsync(int userId)
        {
            var samples = await _sampleService.GetUserSamplesAsync(userId);
            return Ok(samples);
        }

        [HttpPost]
        public async Task<ActionResult<SampleDto>> CreateAsync(NewSampleDto sampleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var sample = await _sampleService.CreateSampleAsync(sampleDto);
            return Ok(sample);
        }

        [HttpPut("{sampleId}")]
        public async Task<ActionResult<SampleDto>> UpdateAsync(int sampleId, NewSampleDto sampleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var sample = await _sampleService.UpdateSampleAsync(sampleId, sampleDto);
            return Ok(sample);
        }

        [HttpDelete("{sampleId}")]
        public async Task<ActionResult> DeleteAsync(int sampleId)
        {
            await _sampleService.DeleteSampleAsync(sampleId);
            
            _logger.LogInformation($"Sample: ID = {sampleId} has been removed.");

            return NoContent();
        }
        
        [HttpPost("rabbitmq_test")]
        public  ActionResult RabbitmqQueueSendTest()
        {
            _queueService.Send("test message");
            return Ok();
        }

        [HttpPost("emailservice_test/{email}")]
        public async Task<ActionResult<string>> EmailServiceTast([FromRoute] string email, [FromBody] ExampleTemplateData data)
        {

            return Ok(await _emailSendService.Send(email, data));
        }
    }
}
