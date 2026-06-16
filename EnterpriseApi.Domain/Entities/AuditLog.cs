using System;

namespace EnterpriseApi.Domain.Entities
{
    public class AuditLog
    {
        public long AuditLogId { get; set; }

        public Guid? UserId { get; set; }

        public string EventType { get; set; }

        public string EventDescription { get; set; }

        public string IpAddress { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}