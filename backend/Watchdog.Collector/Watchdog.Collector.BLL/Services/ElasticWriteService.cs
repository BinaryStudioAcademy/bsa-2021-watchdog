using AutoMapper;
using Nest;
using System;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.DTO.Issue;
using Watchdog.Common.Messages;
using Watchdog.Models.Shared.Analytics;
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

        public async Task LogResponse(ResponseInfo response)
        {
            if (!string.IsNullOrEmpty(response.Url))
            {
                await _client.IndexDocumentAsync<ResponseInfo>(response);
            }
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
            // мапінг моделі, що приходи до внутрішньої моделі
            var issueMessage = _mapper.Map<IssueMessage>(message);

            if (string.IsNullOrEmpty(issueMessage.IssueDetails.ErrorMessage))
            {
                throw new ArgumentException("Error message can't be empty.");
            }
            // виклик допоміжної функції
            return WriteNewEventMessageAsync(issueMessage);
        }

        private async Task WriteNewEventMessageAsync(IssueMessage issueMessage)
        {
            // створюємо новий id
            issueMessage.Id = Guid.NewGuid().ToString();
            // записуємо до Elastic Search
            await _client.IndexDocumentAsync(issueMessage);
            // додаємо у чергу RabbitMQ
            _issueProducer.ProduceMessage(issueMessage);
        }

        public async Task AddProjectCountryInfoAsync(CountryInfo countryInfo)
        {
            var searchResponse = _client.Search<CountryInfo>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.SessionId)
                        .Query(countryInfo.SessionId)
                        .Operator(Operator.And)
                    )
                )
            );

            if (!searchResponse.Documents.Any())
            {
                await _client.IndexDocumentAsync<CountryInfo>(countryInfo);
            }
        }
    }
}