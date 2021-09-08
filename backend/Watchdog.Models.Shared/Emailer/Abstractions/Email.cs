using System.Collections.Generic;

namespace Watchdog.Models.Shared.Emailer.Abstractions
{
    public abstract class Email
    {
        public abstract string TemplateId { get; }
        public object TemplateData { get; set; }
        public virtual ICollection<Recipient> Recipients { get; set; }
        public virtual EmailSettings Settings { get; set; }
    }
}
