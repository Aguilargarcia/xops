using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xops.common.Controller;

namespace xops.user.api.Controllers
{
    public class UserController : BaseController
    {

        [HttpGet("user")]
        public IActionResult GetUser()
        {
            return Ok();
        }
    }
}
