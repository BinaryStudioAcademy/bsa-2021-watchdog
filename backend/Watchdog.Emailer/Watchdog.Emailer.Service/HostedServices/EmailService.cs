using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchdog.Emailer.Service.Abstractions;
using Watchdog.Emailer.Service.Settings;
using Watchdog.Models.Shared.Emailer.Abstractions;
using Watchdog.RabbitMQ.Shared.Services;

namespace Watchdog.Emailer.Service.HostedServices
{
    public class EmailService : IHostedService
    {
        private readonly RabbitMQSettings _rabbitMQSettings;
        private readonly ILogger _logger;
        private readonly IEmailSender _emailSender;
        private Consumer _consumer;

        public EmailService(IOptions<RabbitMQSettings> rabbitMQSettings,
                            ILogger<EmailService> logger,
                            IEmailSender emailSender)
        {
            _logger = logger;
            _rabbitMQSettings = rabbitMQSettings.Value;
            _emailSender = emailSender;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"EmailService is starting.");
            ConnectConsumer();
            _logger.LogInformation($"EmailService has started.");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"EmailService background task is stopping.");
            _consumer.Dispose();

            return Task.CompletedTask;
        }

        private void ConnectConsumer()
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_rabbitMQSettings.Uri)
            };

            _consumer = new Consumer(factory.CreateConnection());
            _consumer.Connect(_rabbitMQSettings.Queues.EmailerQueueConsumer, Received);
        }

        private void Received(object sender, BasicDeliverEventArgs arg)
        {
            Task.Run(async () =>
            {
                // десереалізуємо email
                var email = DeserializeEmail(arg.Body.ToArray());
                // нічого не відправляємо, якщо немає отримувачів
                if (email.Recipients.Count == 0)
                {
                    _consumer.SetAcknowledge(arg.DeliveryTag, true);
                    return;
                }
                // відправляєм email за допомогою SendGrid
                var response = await _emailSender.SendEmail(email);
                if (response.IsSuccessStatusCode)
                {
                    // у разі успішної відправки позначаємо,
                    // що повідомлення опрацьовано
                    _consumer.SetAcknowledge(arg.DeliveryTag, true);
                }
            });
        }

        private static Email DeserializeEmail(byte[] content)
        {
            var body = Encoding.UTF8.GetString(content);

            return JsonConvert.DeserializeObject<Email>(body, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }
    }
}
