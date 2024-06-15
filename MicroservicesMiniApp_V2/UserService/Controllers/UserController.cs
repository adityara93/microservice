using JwtAuthenticationManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JwtTokenHandler _tokenHandler;

        public UserController(JwtTokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }
        [HttpPost]
        public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest authRequest)
        {
            var authResponse = _tokenHandler.GenerateJwtToken(authRequest);
            if (authResponse == null)
            {
                return Unauthorized();
            }
            return authResponse;
        }
    }
}
