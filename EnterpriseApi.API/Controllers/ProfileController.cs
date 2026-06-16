using EnterpriseApi.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EnterpriseApi.API.Controllers
{
    [ApiController]
    [Route("api/profile")]
    [Authorize(Policy = AuthorizationPolicies.AuthenticatedUser)]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                UserName = User.Identity.Name,

                Email = User.Claims
                    .FirstOrDefault(x =>
                        x.Type ==
                        System.Security.Claims.ClaimTypes.Email)
                    ?.Value
            });
        }
    }
}