using EnterpriseApi.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseApi.API.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrManager)]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Message = "Dashboard Access Granted"
            });
        }
    }
}