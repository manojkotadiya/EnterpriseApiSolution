using EnterpriseApi.Domain.Entities;
using System.Threading.Tasks;

namespace EnterpriseApi.Application.Interfaces
{
    public interface IRefreshTokenService
    {
        Task SaveRefreshTokenAsync(
            Client client,
            string refreshToken);

        Task<RefreshToken> GetRefreshTokenAsync(
            string token);

        Task RevokeRefreshTokenAsync(
            RefreshToken refreshToken);
    }
}