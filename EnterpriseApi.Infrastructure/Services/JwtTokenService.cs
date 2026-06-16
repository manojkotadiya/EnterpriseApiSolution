using EnterpriseApi.Application.Configurations;
using EnterpriseApi.Application.DTOs;
using EnterpriseApi.Application.Interfaces;
using EnterpriseApi.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EnterpriseApi.Infrastructure.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenService(
            IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public TokenResponseDto GenerateToken(
            Client client)
        {
            var tokenHandler =
                new JwtSecurityTokenHandler();

            var key =
                Encoding.UTF8.GetBytes(
                    _jwtSettings.SecretKey);

            var claims = new[]
            {
                new Claim(
                    JwtRegisteredClaimNames.Sub,
                    client.ClientId.ToString()),

                new Claim(
                    "client_key",
                    client.ClientKey),

                new Claim(
                    JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            };
            foreach (var role in user.UserRoles)
            {
                claims.Add(
                    new Claim(
                        ClaimTypes.Role,
                        role.Role.RoleName));
            }

            var expiresAt =
                DateTime.UtcNow.AddMinutes(
                    _jwtSettings.AccessTokenExpirationMinutes);

            var descriptor =
                new SecurityTokenDescriptor
                {
                    Subject =
                        new ClaimsIdentity(claims),

                    Expires = expiresAt,

                    Issuer = _jwtSettings.Issuer,

                    Audience = _jwtSettings.Audience,

                    SigningCredentials =
                        new SigningCredentials(
                            new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256Signature)
                };

            var token =
                tokenHandler.CreateToken(descriptor);

            return new TokenResponseDto
            {
                AccessToken =
                    tokenHandler.WriteToken(token),

                RefreshToken =
                    GenerateRefreshToken(),

                ExpiresAt = expiresAt
            };
        }

        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];

            using var rng =
                RandomNumberGenerator.Create();

            rng.GetBytes(randomBytes);

            return Convert.ToBase64String(randomBytes);
        }
        public TokenResponseDto GenerateToken(
    User user)
        {
            var tokenHandler =
                new JwtSecurityTokenHandler();

            var key =
                Encoding.UTF8.GetBytes(
                    _jwtSettings.SecretKey);

            var claims = new List<Claim>
    {
        new Claim(
            JwtRegisteredClaimNames.Sub,
            user.UserId.ToString()),

        new Claim(
            ClaimTypes.Email,
            user.Email),

        new Claim(
            ClaimTypes.Name,
            user.UserName)
    };

            foreach (var role in user.UserRoles)
            {
                claims.Add(
                    new Claim(
                        ClaimTypes.Role,
                        role.Role.RoleName));
            }

            var expiresAt =
                DateTime.UtcNow.AddMinutes(
                    _jwtSettings.AccessTokenExpirationMinutes);

            var descriptor =
                new SecurityTokenDescriptor
                {
                    Subject =
                        new ClaimsIdentity(claims),

                    Expires = expiresAt,

                    Issuer = _jwtSettings.Issuer,

                    Audience = _jwtSettings.Audience,

                    SigningCredentials =
                        new SigningCredentials(
                            new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256Signature)
                };

            var token =
                tokenHandler.CreateToken(
                    descriptor);

            return new TokenResponseDto
            {
                AccessToken =
                    tokenHandler.WriteToken(token),

                RefreshToken =
                    GenerateRefreshToken(),

                ExpiresAt =
                    expiresAt
            };
        }
    }
}