using EnterpriseApi.Domain.Entities;
using System.Threading.Tasks;

namespace EnterpriseApi.Application.Interfaces
{
    public interface IClientValidationService
    {
        Task<Client> ValidateClientAsync(
            string clientId,
            string clientSecret);
    }
}