using System;

namespace EnterpriseApi.Domain.Entities
{
    public class RefreshToken
    {
        public Guid RefreshTokenId { get; set; }

        public Guid ClientId { get; set; }

        public string Token { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public bool Revoked { get; set; }

        public Client Client { get; set; }

        public bool IsExpired =>
            DateTime.UtcNow >= ExpiresAt;
    }
}