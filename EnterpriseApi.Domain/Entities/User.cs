using System;
using System.Collections.Generic;

namespace EnterpriseApi.Domain.Entities
{
    public class User
    {
        public User()
        {
            UserRoles = new List<UserRole>();
            RefreshTokens = new List<RefreshToken>();
        }
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
