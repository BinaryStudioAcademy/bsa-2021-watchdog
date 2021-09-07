using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Watchdog.Core.BLL.Services
{
    public static class StackExchangeService
    {
        private static readonly Uri _baseUri = new Uri("https://api.stackexchange.com/2.3/similar");
        private static readonly Uri _baseUriAnswer = new Uri("https://api.stackexchange.com/2.3/answers");

        public static async Task<T> GetAnswerFromStackoverflow<T>(int answerId)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (HttpClient client = new HttpClient(handler))
            {
                var uriBuilder = new UriBuilder(_baseUriAnswer);

                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["id"] = answerId.ToString();
                query["site"] = "stackoverflow";
                query["sort"] = "activity";
                query["filter"] = "withbody";
                uriBuilder.Query = query.ToString();
                var url = uriBuilder.ToString();

                var request = new HttpRequestMessage(HttpMethod.Get, url);

                HttpResponseMessage response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                var answer = JsonConvert.DeserializeObject<T>(responseContent);

                return answer;
            }
        }

        public static async Task<T> GetSolutionFromStackoverflow<T>(string messsage, string[] tags)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (HttpClient client = new HttpClient(handler))
            {
                var uriBuilder = new UriBuilder(_baseUri);

                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["site"] = "stackoverflow";
                query["title"] = messsage;
                query["tagged"] = string.Join(" ", tags.Select(str => str.Replace(' ', '-')));
                query["sort"] = "relevance";
                query["pagesize"] = "5";
                query["filter"] = "withbody";
                uriBuilder.Query = query.ToString();
                var url = uriBuilder.ToString();

                var request = new HttpRequestMessage(HttpMethod.Get, url);

                HttpResponseMessage response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                var solution = JsonConvert.DeserializeObject<T>(responseContent);

                return solution;
            }
        }
    }
}
