using EnterpriseApi.Domain.Entities;
using System.Threading.Tasks;

namespace EnterpriseApi.Application.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<User> AuthenticateAsync(
            string email,
            string password);
    }
}