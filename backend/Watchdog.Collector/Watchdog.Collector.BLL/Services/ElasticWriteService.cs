using System;
using System.Threading.Tasks;
using Nest;
using Watchdog.Collector.BLL.Entities;
using Watchdog.Collector.BLL.Services.Abstract;

namespace Watchdog.Collector.BLL.Services
{
    public class ElasticWriteService : IElasticWriteService
    {
        private readonly IElasticClient _client;

        public ElasticWriteService(IElasticClient client)
        {
            _client = client;
        }
            
        public async Task AddIssueAsync(IssueMessage message)
        {
            var indexResponse = await _client.IndexDocumentAsync<IssueMessage>(message);
            
            if (!indexResponse.IsValid)
                throw new InvalidOperationException("Invalid index response");
        } 
    }
}