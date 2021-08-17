using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.Models;
using Watchdog.RabbitMQ.Shared.Services;
using IConnection = RabbitMQ.Client.IConnection;

namespace Watchdog.Collector.BLL.Services
{
    public class ElasticWriteService : IElasticWriteService
    {
        private readonly IElasticClient _client;
        private readonly IIssueProducerService _issueProducer;

        public ElasticWriteService(IElasticClient client, IIssueProducerService issueProducer)
        {
            _client = client;
            _issueProducer = issueProducer;
        }

        public async Task AddIssueAsync(IssueMessage message)
        {
            var indexResponse = await _client.IndexAsync(message, t => t.Refresh(Refresh.WaitFor));

            if (!indexResponse.IsValid)
                throw new InvalidOperationException("Invalid index response");

            _issueProducer.ProduceMessage(message);
        }
    }
}