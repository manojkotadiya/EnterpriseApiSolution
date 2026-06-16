using EnterpriseApi.Application.DTOs;
using EnterpriseApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EnterpriseApi.API.Extensions;
using System;

namespace EnterpriseApi.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IClientValidationService _clientValidationService;

        private readonly IJwtTokenService _jwtTokenService;

        private readonly IRefreshTokenService _refreshTokenService;

        private readonly IClientRepository _clientRepository;

        private readonly IUserAuthenticationService _userAuthenticationService;

        public AuthController(
                IClientValidationService clientValidationService,
                IJwtTokenService jwtTokenService,
                IRefreshTokenService refreshTokenService, 
                IClientRepository clientRepository, 
                IUserAuthenticationService userAuthenticationService)
        {
            _clientValidationService = clientValidationService;
            _jwtTokenService = jwtTokenService;
            _refreshTokenService = refreshTokenService;
            _clientRepository = clientRepository;
            _userAuthenticationService = userAuthenticationService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken(
            [FromBody] TokenRequestDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var client =
                await _clientValidationService
                    .ValidateClientAsync(
                        request.ClientId,
                        request.ClientSecret);

            if (client == null)
            {
                return Unauthorized(new
                {
                    Message = "Invalid Client Credentials"
                });
            }

            var token = _jwtTokenService.GenerateToken(client);

            await _refreshTokenService
                .SaveRefreshTokenAsync(
                    client,
                    token.RefreshToken);

            return Ok(token);
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(
    [FromBody] RefreshTokenRequestDto request)
        {
            var storedToken =
                await _refreshTokenService
                    .GetRefreshTokenAsync(
                        request.RefreshToken);

            if (storedToken == null)
            {
                return Unauthorized();
            }

            if (storedToken.Revoked ||
                storedToken.IsExpired)
            {
                return Unauthorized();
            }

            var client =
                await _clientRepository
                    .GetByIdAsync(
                        storedToken.ClientId);

            if (client == null)
            {
                return Unauthorized();
            }

            await _refreshTokenService
                .RevokeRefreshTokenAsync(
                    storedToken);

            var token =
                _jwtTokenService
                    .GenerateToken(client);

            await _refreshTokenService
                .SaveRefreshTokenAsync(
                    client,
                    token.RefreshToken);

            return Ok(token);
        }
        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            return Ok(new
            {
                ClientKey =
                    User.GetClientKey(),

                Subject =
                    User.GetSubjectId()
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var user =
                await _userAuthenticationService
                    .AuthenticateAsync(
                        request.Email,
                        request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token =
                _jwtTokenService
                    .GenerateToken(user);

            return Ok(token);
        }
        [HttpGet("error")]
        public IActionResult Error()
        {
            throw new Exception("Test Error");
        }
        [HttpGet("correlation")]
        public IActionResult Correlation()
        {
            return Ok(new
            {
                CorrelationId =
                    HttpContext.GetCorrelationId()
            });
        }
    }
}