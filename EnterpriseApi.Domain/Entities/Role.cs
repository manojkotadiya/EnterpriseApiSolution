using System;
using System.Collections.Generic;

namespace EnterpriseApi.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            UserRoles = new List<UserRole>();
        }
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public string Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}