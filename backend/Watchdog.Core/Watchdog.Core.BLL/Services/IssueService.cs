using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.BLL.Services
{
    public class IssueService : IIssueService
    {
        private readonly IElasticClient _client;
        
        public IssueService(IElasticClient client)
        {
            _client = client;
        }
        
        public async Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync()
        {
            var totalHits = await GetTotalHits();
            
            var searchResponse = await _client.SearchAsync<IssueMessage>(s => s
                .Source(sf => sf
                    .IncludeAll()
                )
                .From(0)
                .Size(totalHits)
            );

            var issueMessages = searchResponse
                .Hits
                .Select(h =>
                {
                    h.Source.Id = h.Id;
                    return h.Source;
                });

            var issues = issueMessages
                .GroupBy(i => new { i.IssueDetails.ClassName, i.IssueDetails.ErrorMessage })
                .Select(group => new IssueInfoDto()
                {
                    ErrorMessage = group.Key.ErrorMessage,
                    ErrorClass = group.Key.ClassName,
                    EventsCount = issueMessages
                        .Count(i => i.IssueDetails.ErrorMessage == group.Key.ErrorMessage),
                    Newest = issueMessages
                        .Where(i => i.IssueDetails.ErrorMessage == group.Key.ErrorMessage)
                        .OrderByDescending(i => i.OccurredOn)
                        .FirstOrDefault(i => i.IssueDetails.ErrorMessage == group.Key.ErrorMessage)
                })
                .OrderByDescending(issue => issue.Newest.OccurredOn)
                .ToList();
            
            return issues;
        }

        private async Task<int> GetTotalHits()
        {
            var totalHits = await _client.CountAsync<IssueMessage>();
            return (int)totalHits.Count;
        }

        public async Task UpdateAssignee(UpdateAssigneeDto assigneeDto)
        {
        }
    }
}