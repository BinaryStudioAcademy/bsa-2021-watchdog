using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Notifier.BLL.Hubs.Interfaces;
using Watchdog.Notifier.BLL.Services.Abstract;
using Watchdog.Notifier.Common.Models.Issue;

namespace Watchdog.Notifier.BLL.Hubs
{
    public class IssuesHub : Hub<IIssuesHubClient>
    {
        public static Dictionary<string, int[]> ConnectionGroups = new();

        private readonly ILogger<IssuesHub> _logger;
        private readonly IIssueConsumerService _issuesConsumer;

        public IssuesHub(ILogger<IssuesHub> logger, IIssueConsumerService issuesConsumer)
        {
            _logger = logger;
            _issuesConsumer = issuesConsumer;
            _issuesConsumer.Connect(Receive);
        }

        public async Task SetProjects(int[] projects)
        {
            var connectionId = Context.ConnectionId;

            await ClearCurrentGroup();
            ConnectionGroups[connectionId] = projects;

            foreach (var project in ConnectionGroups[connectionId])
            {
                await Groups.AddToGroupAsync(connectionId, project.ToString());
            }
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            ConnectionGroups.Add(this.Context.ConnectionId, new int[] { });
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            ConnectionGroups.Remove(this.Context.ConnectionId);
        }

        private async Task ClearCurrentGroup()
        {
            var connectionId = Context.ConnectionId;

            foreach (var project in ConnectionGroups[connectionId])
            {
                await Groups.RemoveFromGroupAsync(connectionId, project.ToString());
            }

            ConnectionGroups[connectionId] = new int[] { };
        }

        private void Receive(object sender, IssueMessage message)
        {
            _logger.LogInformation("Received datas: {0}", message.IssueDetails);

            //TODO: Change this '2' to project id when it will be ready to pass
            Clients.Group("2").SendIssue(message);
        }
    }
}
