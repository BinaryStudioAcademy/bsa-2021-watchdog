using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.BLL.Services;
using Watchdog.Core.BLL.Services.Abstract;

namespace Watchdog.Core.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {

        private readonly QueueService _queueService;
        private readonly IEmailSendService _emailSendService;

        public SampleController(QueueService queueService,
                                IEmailSendService emailSendService)
        {
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
