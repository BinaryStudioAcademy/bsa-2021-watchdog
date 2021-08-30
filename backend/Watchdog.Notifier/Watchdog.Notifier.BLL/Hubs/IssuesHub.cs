using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Watchdog.Notifier.BLL.Hubs.Interfaces;

namespace Watchdog.Notifier.BLL.Hubs
{
    [Authorize]
    public class IssuesHub : Hub<IIssuesHubClient>
    {
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var memberId = httpContext.Request.Query["memberId"].ToString();

            Context.Items.Add("memberId", memberId);

            await Groups.AddToGroupAsync(Context.ConnectionId, memberId);
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            var memberId = Context.Items["memberId"].ToString();

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, memberId);
        }
    }
}
