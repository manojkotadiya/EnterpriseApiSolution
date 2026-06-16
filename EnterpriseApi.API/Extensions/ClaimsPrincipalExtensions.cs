using System.Linq;
using System.Security.Claims;

namespace EnterpriseApi.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetClientKey(
            this ClaimsPrincipal principal)
        {
            return principal.Claims
                .FirstOrDefault(x =>
                    x.Type == "client_key")
                ?.Value;
        }

        public static string? GetSubjectId(
            this ClaimsPrincipal principal)
        {
            return principal.Claims
                .FirstOrDefault(x =>
                    x.Type == ClaimTypes.NameIdentifier
                     || x.Type == "sub")
                ?.Value;
        }
        public static string? GetEmail(
    this ClaimsPrincipal principal)
        {
            return principal.Claims
                .FirstOrDefault(x =>
                    x.Type == ClaimTypes.Email)
                ?.Value;
        }

        public static string? GetUserName(
            this ClaimsPrincipal principal)
        {
            return principal.Identity?.Name;
        }
    }
}