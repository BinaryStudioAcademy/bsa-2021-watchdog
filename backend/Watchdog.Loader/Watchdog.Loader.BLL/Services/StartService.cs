using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Loader.BLL.Helpers;
using Watchdog.Loader.BLL.Services.Abstract;
using Watchdog.Models.Shared.Loader;
using Watchdog.Models.Shared.Loader.LoadTestSetting;

namespace Watchdog.Loader.BLL.Services
{
    public class StartService : IStartService
    {
        readonly IElasticService _elastic;
        private readonly ILogger<StartService> _logger;

        public StartService(IElasticService elastic, ILogger<StartService> logger)
        {
            _elastic = elastic;
            _logger = logger;
        }

        public async Task StartTestAsync(LoaderMessage message)
        {
            await _elastic.ClearAsync(message.Id);
            switch (message.Type)
            {
                case TestType.ClientsPerTest:
                    StartClientPerTest(message);
                    break;
                case TestType.ClientsPerSecond:
                    StartClientPerSecond(message);
                    break;
                case TestType.MaintainClientLoad:
                    StartMaintainClientLoad(message);
                    break;
                default:
                    throw new ArgumentException(nameof(message.Type));
            }
        }

        private void StartMaintainClientLoad(LoaderMessage message)
        {
            StartClientPerSecond(message); // Now it works like ClientPerSecond
        }

        private void StartClientPerSecond(LoaderMessage message)
        {
            var timer = new TimerHelper(1000, message.Duration);

            timer.Elapsed += (sender, args) =>
            {
                foreach (var request in message.Requests)
                {
                    Parallel.For(0, message.Clients, i =>
                    {
                        _ = SendRequest(request, message.Id);
                    });
                }
            };
            timer.Start();
            _logger.LogInformation("Start testing");
        }
        private void StartClientPerTest(LoaderMessage message)
        {
            var timer = new TimerHelper(1000, message.Duration);

            var clients = message.Clients / (int)message.Duration.TotalSeconds;
            var adittionalClients = message.Clients % (int)message.Duration.TotalSeconds;

            int counter = 0;
            timer.Elapsed += (sender, args) =>
            {
                ++counter;
                foreach (var request in message.Requests)
                {
                    Parallel.For(0, counter <= adittionalClients ? clients + 1 : clients, i =>
                    {
                        _ = SendRequest(request, message.Id);
                    });
                }
            };
            timer.Start();
        }

        private static HttpRequestMessage GetRequest(Request model)
        {
            HttpMethod method = model.Method switch
            {
                TestMethod.Get => HttpMethod.Get,
                TestMethod.Post => HttpMethod.Post,
                TestMethod.Put => HttpMethod.Put,
                TestMethod.Delete => HttpMethod.Delete,
                TestMethod.Patch => HttpMethod.Patch,
                _ => throw new ArgumentException(nameof(model.Method))
            };
            var protocol = model.Protocol == TestProtocol.Https ? "https" : "http";
            var path = string.IsNullOrWhiteSpace(model.Path) ? "" : $"/{model.Path}";
            var uri = QueryHelpers.AddQueryString($"{protocol}://{model.Host}{path}", JsonConvert.DeserializeObject<Dictionary<string, string>>(model.Parameters));
            var request = new HttpRequestMessage(method, uri);
            var headers = JsonConvert.DeserializeObject<Dictionary<string, string>>(model.Headers);
            foreach (var header in headers)
            {
                if (header.Key != "content-type")
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            if (model.Method != TestMethod.Get && model.Method != TestMethod.Delete)
            {
                request.Content = new StringContent(model.Body ?? "",
                    Encoding.UTF8,
                    headers["content-type"]);
            }
            return request;
        }

        private async Task SendRequest(Request request, int id)
        {
            var result = new TestResult()
            {
                Id = Guid.NewGuid().ToString(),
                RequestId = request.Id,
                TestId = id,
                SentSize = Encoding.UTF8.GetBytes(request.Body ?? "").Length
            };
            using var client = new HttpClient();
            var stopWatch = Stopwatch.StartNew();
            try
            {
                _logger.LogInformation($"Send request with id = {request.Id} ({result.Id})");
                var response = await client.SendAsync(GetRequest(request));
                result.ResponseTime = stopWatch.Elapsed;
                _logger.LogInformation($"Recive request with id = {request.Id} ({result.Id})");
                result.StatusCode = response.StatusCode;
                result.ReceivedSize = (await response.Content.ReadAsByteArrayAsync()).Length;
            }
            catch (HttpRequestException e)
            {
                result.ResponseTime = stopWatch.Elapsed;
                _logger.LogWarning($"Faliled request with id = {request.Id} ({result.Id}): ${e.Message}");
                result.IsFailed = true;
                throw;
            }
            finally
            {
                await _elastic.AddTestResultAsync(result);
            }

        }
    }
}
