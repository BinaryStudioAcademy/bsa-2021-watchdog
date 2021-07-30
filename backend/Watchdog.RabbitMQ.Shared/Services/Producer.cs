using System.Text;
using RabbitMQ.Client;
using Watchdog.RabbitMQ.Shared.Interfaces;
using Watchdog.RabbitMQ.Shared.Models;

namespace Watchdog.RabbitMQ.Shared.Services
{
    public class Producer : IProducer
    {
        private readonly IConnection _connection;
        private readonly ProducerSettings _producerSettings;

        public Producer(IConnection connection, ProducerSettings producerSettings)
        {
            _connection = connection;
            _producerSettings = producerSettings;
        }

        public void Send(string message, string? type)
        {
            using var channel = _connection.CreateModel();
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            if (!string.IsNullOrEmpty(type)) properties.Type = type;

            channel.ExchangeDeclare(_producerSettings.ExchangeName, _producerSettings.ExchangeType);

            if (!string.IsNullOrEmpty(_producerSettings.QueueName))
            {
                channel.QueueDeclare(
                    _producerSettings.QueueName,
                    true,
                    false,
                    false);
                channel.QueueBind(
                    _producerSettings.QueueName,
                    _producerSettings.ExchangeName,
                    _producerSettings.RoutingKey);
            }

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                new PublicationAddress(
                    _producerSettings.ExchangeType,
                    _producerSettings.ExchangeName,
                    _producerSettings.RoutingKey),
                properties,
                body);
        }
    }
}