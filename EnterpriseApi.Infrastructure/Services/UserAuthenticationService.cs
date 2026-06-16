using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Domain.Entities;
using System.Threading.Tasks;

namespace EnterpriseApi.Infrastructure.Services
{
    public class UserAuthenticationService
        : IUserAuthenticationService
    {
        private readonly IUserRepository
            _userRepository;

        private readonly IPasswordHasher
            _passwordHasher;

        public UserAuthenticationService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> AuthenticateAsync(
            string email,
            string password)
        {
            var user =
                await _userRepository
                    .GetUserWithRolesAsync(email);

            if (user == null)
                return null;

            if (!_passwordHasher.Verify(
                    password,
                    user.PasswordHash))
            {
                return null;
            }

            return user;
        }
    }
}