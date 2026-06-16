using EnterpriseApi.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseApi.API.Controllers
{
    [ApiController]
    [Route("api/manager")]
    [Authorize(Policy = AuthorizationPolicies.ManagerOnly)]
    public class ManagerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Message = "Manager Access Granted"
            });
        }
    }
}