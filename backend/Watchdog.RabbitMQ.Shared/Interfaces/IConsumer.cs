using System;
using RabbitMQ.Client.Events;
using Watchdog.RabbitMQ.Shared.Models;

namespace Watchdog.RabbitMQ.Shared.Interfaces
{
    public interface IConsumer : IDisposable
    {
        void SetAcknowledge(ulong deliveryTag, bool processed);

        void Connect(ConsumerSettings settings, EventHandler<BasicDeliverEventArgs> received);
    }
}