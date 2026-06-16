using EnterpriseApi.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseApi.API.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Policy = AuthorizationPolicies.AdminOnly)]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Message = "Admin Access Granted"
            });
        }
    }
}