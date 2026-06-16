using EnterpriseApi.Application.DTOs;
using EnterpriseApi.Domain.Entities;

namespace EnterpriseApi.Application.Interfaces
{
    public interface IJwtTokenService
    {
        TokenResponseDto GenerateToken(Client client);

        string GenerateRefreshToken();
        TokenResponseDto GenerateToken(User user);
    }
}