using Newtonsoft.Json;

namespace Watchdog.Core.BLL.Models
{
    // I used the basic sendgrid template, so the email is automatically sended in the promotions.
    // To change template change it template id
    public class ExampleTemplateData
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}
