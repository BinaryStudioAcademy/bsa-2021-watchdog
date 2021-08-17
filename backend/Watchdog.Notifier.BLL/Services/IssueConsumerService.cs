using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Watchdog.Notifier.Common.Models.Issue;
using Watchdog.Notifier.BLL.Hubs;
using Watchdog.Notifier.BLL.Hubs.Interfaces;
using Watchdog.Notifier.BLL.Services.Abstract;
using Watchdog.RabbitMQ.Shared.Services;
using Watchdog.RabbitMQ.Shared.Models;
using System;

namespace Watchdog.Notifier.BLL.Services
{
    public class IssueConsumerService : IIssueConsumerService
    {
        private readonly Consumer _consumer;
        private event EventHandler<IssueMessage> _dataAccepted;

        public IssueConsumerService(
            IConnection connection,
            ConsumerSettings settings)
        {
            _consumer = new Consumer(connection);
            _consumer.Connect(settings, Received);

        }

        public void Connect(EventHandler<IssueMessage> received)
        {
            _dataAccepted += received;
        }

        public void SetAcknowledge(ulong deliveryTag)
        {
            _consumer.SetAcknowledge(deliveryTag, true);
        }

        private void Received(object sender, BasicDeliverEventArgs arg)
        {
            var messageString = Encoding.UTF8.GetString(arg.Body.Span);
            var issueMessage = JsonConvert.DeserializeObject<IssueMessage>(messageString);

            SetAcknowledge(arg.DeliveryTag);

            _dataAccepted(this, issueMessage);
        }
    }
}

