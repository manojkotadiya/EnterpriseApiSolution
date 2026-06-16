using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace EnterpriseApi.Infrastructure.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository
            _refreshTokenRepository;

        public RefreshTokenService(
            IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository =
                refreshTokenRepository;
        }

        public async Task SaveRefreshTokenAsync(
            Client client,
            string refreshToken)
        {
            var token = new RefreshToken
            {
                RefreshTokenId = Guid.NewGuid(),

                ClientId = client.ClientId,

                Token = refreshToken,

                CreatedAt = DateTime.UtcNow,

                ExpiresAt = DateTime.UtcNow.AddDays(7),

                Revoked = false
            };

            await _refreshTokenRepository.AddAsync(token);

            await _refreshTokenRepository.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetRefreshTokenAsync(
            string token)
        {
            return await _refreshTokenRepository
                .GetByTokenAsync(token);
        }

        public async Task RevokeRefreshTokenAsync(
            RefreshToken refreshToken)
        {
            refreshToken.Revoked = true;

            await _refreshTokenRepository.SaveChangesAsync();
        }
    }
}