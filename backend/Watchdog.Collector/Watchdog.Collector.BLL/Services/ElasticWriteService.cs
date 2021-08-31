using AutoMapper;
using Nest;
using System;
using System.Threading.Tasks;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.DTO.Issue;
using Watchdog.Common.Messages;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Collector.BLL.Services
{
    public class ElasticWriteService : IElasticWriteService
    {
        private readonly IElasticClient _client;
        private readonly IMapper _mapper;
        private readonly IIssueQueueProducerService _issueProducer;
        
        public ElasticWriteService(IElasticClient client, IMapper mapper, IIssueQueueProducerService issueProducer)
        {
            _client = client;
            _mapper = mapper;
            _issueProducer = issueProducer;
        }
        
        public Task AddIssueMessageAsync(IssueMessageDto message)
        {
            var issueMessage = _mapper.Map<IssueMessage>(message);
                
            if (string.IsNullOrEmpty(issueMessage.IssueDetails.ErrorMessage))
            {
                throw new ArgumentException("Error message can't be empty.");
            }

            return WriteNewEventMessageAsync(issueMessage);
        }

        public Task AddIssueAsync(WatchdogMessage message)
        {
            var issueMessage = _mapper.Map<IssueMessage>(message);

            if (string.IsNullOrEmpty(issueMessage.IssueDetails.ErrorMessage))
            {
                throw new ArgumentException("Error message can't be empty.");
            }

            return WriteNewEventMessageAsync(issueMessage);
        }

        private async Task WriteNewEventMessageAsync(IssueMessage issueMessage)
        {
            issueMessage.Id = Guid.NewGuid().ToString();
            
            await _client.IndexDocumentAsync<IssueMessage>(issueMessage);
            
            _issueProducer.ProduceMessage(issueMessage);
        }
    }
}