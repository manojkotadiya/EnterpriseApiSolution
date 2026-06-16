using EnterpriseApi.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace EnterpriseApi.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Client> Clients { get; }

        IRepository<User> Users { get; }

        IRepository<Role> Roles { get; }

        IRepository<UserRole> UserRoles { get; }

        IRepository<RefreshToken> RefreshTokens { get; }

        IRepository<AuditLog> AuditLogs { get; }

        Task<int> SaveChangesAsync();
    }
}