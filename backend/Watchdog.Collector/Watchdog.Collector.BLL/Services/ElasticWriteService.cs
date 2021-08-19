using System;
using System.Threading.Tasks;
using AutoMapper;
using Nest;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.Models;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.Collector.BLL.Services
{
    public class ElasticWriteService : IElasticWriteService
    {
        private readonly IElasticClient _client;
        private readonly IMapper _mapper;

        public ElasticWriteService(IElasticClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }
            
        public async Task AddIssueAsync(IssueMessage message)
        {
            var indexResponse = await _client.IndexDocumentAsync<IssueMessage>(message);
            
            if (!indexResponse.IsValid)
                throw new InvalidOperationException("Invalid index response");
        }

        public async Task AddIssueAsync(WatchdogMessage message)
        {
            var issueMessage = _mapper.Map<IssueMessage>(message);

            var indexResponse = await _client.IndexDocumentAsync(issueMessage);

            if (!indexResponse.IsValid)
                throw new InvalidOperationException("Invalid index response");
        }
    }
}