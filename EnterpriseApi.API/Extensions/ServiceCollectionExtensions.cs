using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnterpriseApi.API.Configurations;
using EnterpriseApi.Infrastructure.Security;
using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Infrastructure.Security;
using EnterpriseApi.Infrastructure.Services;
using EnterpriseApi.Persistence.Repositories;
using EnterpriseApi.Application.Configurations;
using EnterpriseApi.Infrastructure.Services;
using EnterpriseApi.Persistence.Repositories;

namespace EnterpriseApi.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtSettings>(
                configuration.GetSection("JwtSettings"));

            services.AddScoped<IClientRepository,
                   ClientRepository>();

            services.AddScoped<IClientValidationService,
                               ClientValidationService>();

            services.AddScoped<IPasswordHasher,
                               PasswordHasher>();

            services.AddScoped<IJwtTokenService,
                               JwtTokenService>();

            services.AddScoped<IRefreshTokenRepository,
                               RefreshTokenRepository>();

            services.AddScoped<IRefreshTokenService,
                               RefreshTokenService>();

            services.AddScoped<IUserRepository,
                   UserRepository>();

            services.AddScoped<IUserAuthenticationService,
                               UserAuthenticationService>();

            return services;
        }
    }
}
