using AutoMapper;
using Nest;
using System;
using System.Threading.Tasks;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.DTO.Issue;
using Watchdog.Collector.Common.Models;

namespace Watchdog.Collector.BLL.Services
{
    public class ElasticWriteService : IElasticWriteService
    {
        private readonly IMapper _mapper;
        private readonly IElasticClient _client;
        private readonly IIssueQueueProducerService _issueProducer;
        
        public ElasticWriteService(IElasticClient client, IMapper mapper, IIssueQueueProducerService issueProducer)
        {
            _client = client;
            _mapper = mapper;
            _issueProducer = issueProducer;
        }
        
        public async Task AddIssueMessageAsync(IssueMessageDto message)
        {
            var issueMessage = _mapper.Map<IssueMessage>(message);
                
            if (string.IsNullOrEmpty(issueMessage.IssueDetails.ErrorMessage))
            {
                throw new ArgumentException("Error message can't be empty.");
            }
            
            var indexResponse = await _client.IndexDocumentAsync<IssueMessage>(issueMessage);
            
            issueMessage.Id = indexResponse.Id;
            
            _issueProducer.ProduceMessage(issueMessage);
        }
    }
}