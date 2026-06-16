using EnterpriseApi.Domain.Entities;
using System.Threading.Tasks;

namespace EnterpriseApi.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);

        Task<RefreshToken> GetByTokenAsync(string token);

        Task SaveChangesAsync();
    }
}
