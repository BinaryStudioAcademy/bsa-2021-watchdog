using Nest;
using System;
using System.Threading.Tasks;
using Watchdog.Loader.BLL.Services.Abstract;
using Watchdog.Models.Shared.Issues;
using Watchdog.Models.Shared.Loader;

namespace Watchdog.Loader.BLL.Services
{
    public class ElasticService : IElasticService
    {
        private readonly IElasticClient _client;

        public ElasticService(IElasticClient client)
        {
            _client = client;
        }

        public Task AddTestResultAsync(TestResult result)
        {
            result.Id ??= Guid.NewGuid().ToString();
            return _client.IndexDocumentAsync(result);
        }

        public Task ClearAsync(int testId)
        {
            return _client.DeleteByQueryAsync<TestResult>(q => q
                .Query(rq => rq
                    .Match(m => m
                        .Field(f => f.TestId)
                        .Query(testId.ToString()))));
        }
    }
}
