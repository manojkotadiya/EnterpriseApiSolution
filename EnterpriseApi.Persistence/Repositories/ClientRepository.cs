using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Domain.Entities;
using EnterpriseApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EnterpriseApi.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetByClientKeyAsync(string clientKey)
        {
            return await _context.Clients
                .FirstOrDefaultAsync(x =>
                    x.ClientKey == clientKey &&
                    x.IsActive);
        }
        public async Task<Client> GetByIdAsync(
        Guid clientId)
        {
            return await _context.Clients
                .FirstOrDefaultAsync(x =>
                    x.ClientId == clientId &&
                    x.IsActive);
        }
    }
}