using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Nest;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.DTO.Issue;
using Watchdog.Collector.Common.Models;

namespace Watchdog.Collector.BLL.Services
{
    public class ElasticWriteService : IElasticWriteService
    {
        private readonly IMapper _mapper;
        private readonly IElasticClient _client;

        public ElasticWriteService(IElasticClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }
            
        public async Task AddIssueMessageAsync(IssueMessageDto message)
        {
            var issueMessage = _mapper.Map<IssueMessage>(message);
            
            if (string.IsNullOrEmpty(issueMessage.IssueDetails.ErrorMessage))
            {
                throw new ArgumentException("Error message can't be empty.");
            }

            await SetIssueIdAsync(issueMessage);

            await IndexNewIssueMessageAsync(issueMessage);
        }

        private async Task IndexNewIssueMessageAsync(IssueMessage issueMessage)
        {
            var indexResponse = await _client.IndexDocumentAsync<IssueMessage>(issueMessage);
                
            if (!indexResponse.IsValid)
            {
                throw new InvalidOperationException("Invalid index response");
            }
        }

        private async Task SetIssueIdAsync(IssueMessage issueMessage)
        {
            var searchResponse = await GetExistingIssuesAsync(issueMessage);

            issueMessage.IssueId = searchResponse.Documents.Count == 0
                ? await CreateNewIssueAsync(issueMessage)
                : GetExistingIssueId(searchResponse);
        }

        private static string GetExistingIssueId(ISearchResponse<Issue> searchResponse)
        {
            return searchResponse.Hits.Select(h => h.Id).FirstOrDefault();
        }
        
        private async Task<ISearchResponse<Issue>> GetExistingIssuesAsync(IssueMessage issueMessage)
        {
            var totalHits = await GetTotalHitsAsync<Issue>();
            
            var searchResponse = await _client.SearchAsync<Issue>(s => s
                .Size(totalHits)
                .Query(q => q
                        .Match(md => md
                            .Field(f => f.ErrorMessage)
                            .Query(issueMessage.IssueDetails.ErrorMessage)
                            .Operator(Operator.And)) && q
                        .Match(md => md
                            .Field(f => f.ErrorClass)
                            .Query(issueMessage.IssueDetails.ClassName)
                            .Operator(Operator.And)
                        )
                )
            );

            return searchResponse;
        }

        private async Task<string> CreateNewIssueAsync(IssueMessage issueMessage)
        {
            var createdIssueResponse = await _client.IndexDocumentAsync<Issue>(new Issue()
            {
                ErrorClass = issueMessage.IssueDetails.ClassName,
                ErrorMessage = issueMessage.IssueDetails.ErrorMessage
            });

            return createdIssueResponse.Id;
        }
        
        private async Task<int> GetTotalHitsAsync<T>() where T: class
        {
            var totalHits = await _client.CountAsync<T>();
            return (int)totalHits.Count;
        }
    }
}