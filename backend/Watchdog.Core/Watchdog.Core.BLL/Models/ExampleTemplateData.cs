using Newtonsoft.Json;

namespace Watchdog.Core.BLL.Models
{

    /* Current template
        
        Subject: {{subject}}

        <html>
        <head>
            <title></title>
        </head>
        <body>
        <style>
            body {
                background: yellow;
            }
        </style>
        Hello {{name}},
        <br /><br/>
        I'm glad you are trying out the dynamic template feature!
        <br /><br/>
        I hope you are having a great day in {{city}} :)
        <br /><br/>
        </body>
        </html>
     */
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
