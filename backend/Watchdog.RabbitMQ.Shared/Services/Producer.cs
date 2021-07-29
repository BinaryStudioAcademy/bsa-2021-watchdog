﻿using System;
using System.Text;
using RabbitMQ.Client;
using Watchdog.RabbitMQ.Shared.Interfaces;
using Watchdog.RabbitMQ.Shared.Models;

namespace Watchdog.RabbitMQ.Shared.Services
{
    public class Producer : IProducer
    {
        private readonly IConnection _connection;

        public Producer(IConnection connection)
        {
            _connection = connection;
        }

        public void Send(string message, ProducerSettings settings, string? type)
        {
            using var channel = _connection.CreateModel();
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            if (!string.IsNullOrEmpty(type))
            {
                properties.Type = type;
            }

            channel.ExchangeDeclare(settings.ExchangeName, settings.ExchangeType);

            if (!string.IsNullOrEmpty(settings.QueueName))
            {
                channel.QueueDeclare(
                    settings.QueueName,
                    true,
                    false,
                    false);
                channel.QueueBind(
                    settings.QueueName,
                    settings.ExchangeName,
                    settings.RoutingKey);
            }

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                new PublicationAddress(
                    settings.ExchangeType,
                    settings.ExchangeName,
                    settings.RoutingKey),
                properties,
                body);
        }
    }
}