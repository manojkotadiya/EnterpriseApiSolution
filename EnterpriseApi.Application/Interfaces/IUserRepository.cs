using EnterpriseApi.Domain.Entities;
using System.Threading.Tasks;

namespace EnterpriseApi.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);

        Task<User> GetUserWithRolesAsync(string email);
    }
}