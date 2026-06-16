using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApi.Domain.Entities
{
    public class Client
    {
        public Guid ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClientKey { get; set; }

        public string ClientSecretHash { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
