namespace Watchdog.Core.BLL.Services.Options
{
    public class EmailSendOptions
    {
        public string ApiKey { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string TemplateId { get; set; }
    }
}
