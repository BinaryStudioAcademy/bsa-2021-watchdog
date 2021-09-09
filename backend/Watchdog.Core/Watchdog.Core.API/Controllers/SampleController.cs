using Microsoft.AspNetCore.Mvc;
using Watchdog.Core.BLL.Services;

namespace Watchdog.Core.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {

        private readonly QueueService _queueService;

        public SampleController(QueueService queueService)
        {
            _queueService = queueService;
        }



        [HttpPost("rabbitmq_test")]
        public ActionResult RabbitmqQueueSendTest()
        {
            _queueService.Send("test message");
            return Ok();
        }
    }
}
