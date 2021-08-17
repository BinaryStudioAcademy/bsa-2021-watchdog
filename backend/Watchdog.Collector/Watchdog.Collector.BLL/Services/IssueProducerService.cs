using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.Models;
using Watchdog.RabbitMQ.Shared.Models;
using Watchdog.RabbitMQ.Shared.Services;

namespace Watchdog.Collector.BLL.Services
{
    public class IssueProducerService : IIssueProducerService
    {
        private readonly Producer _producer;

        public IssueProducerService(IConnection connection, ProducerSettings settings)
        {
            _producer = new Producer(connection, settings);
        }

        public void ProduceMessage(IssueMessage message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            _producer.Send(jsonMessage, "JSON");
        }
    }
}
