using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Loader.BLL.Services.Abstract;
using Watchdog.Models.Shared.Loader;
using Watchdog.Models.Shared.Loader.LoadTestSetting;

namespace Watchdog.Loader.BLL.Services
{
    public class StartService : IStartService
    {
        public async Task StartTestAsync(LoaderMessage message)
        {
            switch (message.Type)
            {
                case TestType.ClientsPerTest:
                    await StartClientPerTest(message);
                    break;
                case TestType.ClientsPerSecond:
                    await StartClientPerSecond(message);
                    break;
                case TestType.MaintainClientLoad:
                    await StartMaintainClientLoad(message);
                    break;
                default:
                    throw new ArgumentException(nameof(message.Type));
            }
        }

        private async Task StartMaintainClientLoad(LoaderMessage message)
        {
            var requests = GetRequests(message);
            foreach (var request in requests)
            {
                await new HttpClient().SendAsync(request);
            }
        }

        private async Task StartClientPerSecond(LoaderMessage message)
        {
            var requests = GetRequests(message);
            foreach (var request in requests)
            {
                await new HttpClient().SendAsync(request);
            }
        }
        private async Task StartClientPerTest(LoaderMessage message)
        {
            var requests = GetRequests(message);
            foreach (var request in requests)
            {
                await new HttpClient().SendAsync(request);
            }
        }

        private static ICollection<HttpRequestMessage> GetRequests(LoaderMessage message)
        {
            return message.Requests.Select(r =>
            {
                HttpMethod method = r.Method switch
                {
                    TestMethod.Get => HttpMethod.Get,
                    TestMethod.Post => HttpMethod.Post,
                    TestMethod.Put => HttpMethod.Put,
                    TestMethod.Delete => HttpMethod.Delete,
                    TestMethod.Patch => HttpMethod.Patch,
                    _ => throw new ArgumentException(nameof(r.Method))
                };
                var protocol = r.Protocol == TestProtocol.Https ? "https" : "http";
                var path = string.IsNullOrWhiteSpace(r.Path) ? "" : $"/{r.Path}";
                var uri = QueryHelpers.AddQueryString($"{protocol}://{r.Host}{path}", JsonConvert.DeserializeObject<Dictionary<string, string>>(r.Parameters));
                var request = new HttpRequestMessage(method, uri);
                var headers = JsonConvert.DeserializeObject<Dictionary<string, string>>(r.Headers);
                foreach (var header in headers)
                {
                    if (header.Key != "content-type")
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
                if (r.Method != TestMethod.Get && r.Method != TestMethod.Delete)
                {
                    request.Content = new StringContent(r.Body,
                        Encoding.UTF8,
                        headers["content-type"]);
                }

                return request;
            }).ToList();
        }
    }
}
