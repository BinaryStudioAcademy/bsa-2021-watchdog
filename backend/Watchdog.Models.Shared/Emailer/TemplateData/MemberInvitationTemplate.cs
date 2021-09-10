using Newtonsoft.Json;

namespace Watchdog.Models.Shared.Emailer.TemplateData
{
    public class MemberInvitationTemplate
    {
        [JsonConstructor]
        public MemberInvitationTemplate()
        {
        }

        public MemberInvitationTemplate(MemberTemplate template)
        {
            Subject = $"Watchdog invitation for {template.Name}";
            Member = template;
        }

        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("member")]
        public MemberTemplate Member { get; set; }
    }

    public class MemberTemplate
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("organization")]
        public OrganizationTemplate Organization { get; set; }
    }

    public class OrganizationTemplate
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("slug")]
        public string OrganizationSlug { get; set; }
    }
}
