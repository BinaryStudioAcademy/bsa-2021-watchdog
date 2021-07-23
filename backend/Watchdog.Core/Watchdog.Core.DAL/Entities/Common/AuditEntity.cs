using System;

namespace Watchdog.Core.DAL.Entities.Common
{
    public abstract class AuditEntity<T> : Entity<T> where T : struct
    {
        public T CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
