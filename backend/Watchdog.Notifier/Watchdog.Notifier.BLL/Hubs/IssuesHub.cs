using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Watchdog.Notifier.BLL.Hubs.Interfaces;

namespace Watchdog.Notifier.BLL.Hubs
{
    [Authorize]
    public class IssuesHub : Hub<IIssuesHubClient>
    {
        // при створенні зв'язку
        public override async Task OnConnectedAsync()
        {
            // отримаємо параметр memberId
            var httpContext = Context.GetHttpContext();
            var memberId = httpContext.Request.Query["memberId"].ToString();
            // запам'ятовуємо memberId
            Context.Items.Add("memberId", memberId);
            // та додаємо до групи
            await Groups.AddToGroupAsync(Context.ConnectionId, memberId);
        }
        //при розівранні зв'язку
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // отримуємо запам'ятований memberId
            var memberId = Context.Items["memberId"].ToString();
            // та видаляємо його з групи
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, memberId); 
        }
    }
}
