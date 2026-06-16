using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Domain.Entities;
using EnterpriseApi.Persistence.Context;
using System.Threading.Tasks;

namespace EnterpriseApi.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<Client> Clients { get; }
        public IRepository<User> Users { get; }
        public IRepository<Role> Roles { get; }
        public IRepository<UserRole> UserRoles { get; }
        public IRepository<RefreshToken> RefreshTokens { get; }
        public IRepository<AuditLog> AuditLogs { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Clients = new Repository<Client>(context);
            Users = new Repository<User>(context);
            Roles = new Repository<Role>(context);
            UserRoles = new Repository<UserRole>(context);
            RefreshTokens = new Repository<RefreshToken>(context);
            AuditLogs = new Repository<AuditLog>(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}