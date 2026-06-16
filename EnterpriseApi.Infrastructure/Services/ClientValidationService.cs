using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Domain.Entities;
using System.Threading.Tasks;

namespace EnterpriseApi.Infrastructure.Services
{
    public class ClientValidationService : IClientValidationService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IPasswordHasher _passwordHasher;

        public ClientValidationService(
            IClientRepository clientRepository,
            IPasswordHasher passwordHasher)
        {
            _clientRepository = clientRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Client> ValidateClientAsync(
            string clientId,
            string clientSecret)
        {
            var client =
                await _clientRepository
                    .GetByClientKeyAsync(clientId);

            if (client == null)
                return null;

            if (!_passwordHasher.Verify(
                    clientSecret,
                    client.ClientSecretHash))
            {
                return null;
            }

            return client;
        }
    }
}