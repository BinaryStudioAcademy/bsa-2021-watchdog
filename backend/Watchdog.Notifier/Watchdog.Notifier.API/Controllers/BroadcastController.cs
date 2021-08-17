using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Watchdog.Notifier.BLL.Hubs;
using Watchdog.Notifier.BLL.Hubs.Interfaces;

namespace Watchdog.Notifier.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BroadcastController : ControllerBase
    {
        private readonly IHubContext<BroadcastHub, IBroadcastHubClient> _hubContext;

        public BroadcastController(IHubContext<BroadcastHub, IBroadcastHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public Task BroadcastMessage(string message)
            => _hubContext.Clients.All.BroadcastMessage(message);
    }
}
