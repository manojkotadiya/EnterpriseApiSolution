using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Domain.Entities;
using EnterpriseApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EnterpriseApi.Persistence.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _context;

        public RefreshTokenRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            RefreshToken refreshToken)
        {
            await _context.RefreshTokens
                .AddAsync(refreshToken);
        }

        public async Task<RefreshToken> GetByTokenAsync(
            string token)
        {
            return await _context.RefreshTokens
                .FirstOrDefaultAsync(x =>
                    x.Token == token &&
                    !x.Revoked);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}