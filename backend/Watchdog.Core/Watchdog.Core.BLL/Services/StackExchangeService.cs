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
                query["pagesize"] = "15";
                query["filter"] = "!T*hPNRA69ofM1izkPP";
                uriBuilder.Query = query.ToString();
                var url = uriBuilder.ToString();

                var request = new HttpRequestMessage(HttpMethod.Get, url);

                HttpResponseMessage response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                try
                {
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
                catch (JsonReaderException)
                {
                    return default;
                }
            }
        }
    }
}
