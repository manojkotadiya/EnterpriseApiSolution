using EnterpriseApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApi.Application.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetByClientKeyAsync(string clientKey);

        Task<Client> GetByIdAsync(Guid clientId);
    }
}
