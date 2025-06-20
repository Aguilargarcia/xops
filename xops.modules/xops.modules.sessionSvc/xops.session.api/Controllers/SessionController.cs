using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xops.common.Controller;
using xops.session.core.Entities;
using xops.session.core.Interfaces;

namespace xops.session.api.Controllers
{
    public class SessionController : BaseController
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login credentials)
        {
            var token = await _sessionService.Login(credentials);
            return Ok(token);
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> Registro(Registro credentials)
        {
            var token = await _sessionService.Registro(credentials);
            return Ok(token);
        }


    }
}
