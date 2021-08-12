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
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {

        private readonly ILogger<SampleController> _logger;
        private readonly QueueService _queueService;
        private readonly IEmailSendService _emailSendService;

        public SampleController(ILogger<SampleController> logger,
                                QueueService queueService,
                                IEmailSendService emailSendService)
        {
            _logger = logger;
            _queueService = queueService;
            _emailSendService = emailSendService;
        }



        [HttpPost("rabbitmq_test")]
        public ActionResult RabbitmqQueueSendTest()
        {
            _queueService.Send("test message");
            return Ok();
        }

        [HttpPost("emailservice_test/{email}")]
        public async Task<ActionResult<string>> EmailServiceTast([FromRoute] string email, [FromBody] ExampleTemplateData data)
        {

            return Ok(await _emailSendService.SendAsync(email, data));
        }
    }
}
