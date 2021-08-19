using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.Models;

namespace Watchdog.Collector.BLL.Services
{
    public class ElasticWriteService : IElasticWriteService
    {
        private readonly IElasticClient _client;
        private readonly IIssueQueueProducerService _issueProducer;

        public ElasticWriteService(IElasticClient client, IIssueQueueProducerService issueProducer)
        {
            _client = client;
            _issueProducer = issueProducer;
        }

        public async Task AddIssueMessageAsync(IssueMessage message)
        {
            if (string.IsNullOrEmpty(message.IssueDetails.ErrorMessage))
            {
                throw new ArgumentException("Error message can't be empty.");
            }

            var indexResponse = await _client.IndexDocumentAsync(message);

            if (!indexResponse.IsValid)
            {
                throw new InvalidOperationException("Invalid index response");
            }

            _issueProducer.ProduceMessage(message);
        }
    }
}