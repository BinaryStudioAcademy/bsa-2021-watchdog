using System.Net.Http;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using System;

namespace Watchdog.Core.BLL.Services
{
    public static class StackExchangeService
    {
        public static async Task<T> GetSolutionFromStackoverflow<T>(string messsage, string[] tags)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (HttpClient client = new HttpClient(handler))
            {
                var uriBuilder = new UriBuilder("https://api.stackexchange.com/2.3/similar");

                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["site"] = "stackoverflow";
                query["title"] = messsage;
                query["tagged"] = string.Join(" ", tags);
                query["sort"] = "relevance";
                query["pagesize"] = "10";
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
