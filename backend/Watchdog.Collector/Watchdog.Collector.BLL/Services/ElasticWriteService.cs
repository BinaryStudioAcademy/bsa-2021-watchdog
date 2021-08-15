using System;
using System.Threading.Tasks;
using Nest;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.Models;

namespace Watchdog.Collector.BLL.Services
{
    public class ElasticWriteService : IElasticWriteService
    {
        private readonly IElasticClient _client;

        public ElasticWriteService(IElasticClient client)
        {
            _client = client;
        }
            
        public async Task AddIssueMessageAsync(IssueMessage message)
        {
            if (string.IsNullOrEmpty(message.ErrorMessage))
            {
                throw new ArgumentException("Error message can't be empty.");
            }
            
            var indexResponse = await _client.IndexDocumentAsync<IssueMessage>(message);

            if (!indexResponse.IsValid)
            {
                throw new InvalidOperationException("Invalid index response");
            }
        } 
    }
}