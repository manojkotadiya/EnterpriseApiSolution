using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EnterpriseApi.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/secure")]
    [Authorize]
    public class SecureController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Message = "Authenticated Successfully"
            });
        }
        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Ok(new
            {
                Claims =
                    User.Claims.Select(x => new
                    {
                        x.Type,
                        x.Value
                    })
            });
        }
    }   
}