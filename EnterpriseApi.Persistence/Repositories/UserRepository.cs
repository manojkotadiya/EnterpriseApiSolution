using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Domain.Entities;
using EnterpriseApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EnterpriseApi.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(
            string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x =>
                    x.Email == email &&
                    x.IsActive);
        }

        public async Task<User> GetUserWithRolesAsync(
            string email)
        {
            return await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x =>
                    x.Email == email &&
                    x.IsActive);
        }
    }
}