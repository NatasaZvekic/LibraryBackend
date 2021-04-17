using Library.Backend.Helpers;
using Library.ServiceContract.DTOs.CreateDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Backend.Controllers
{

    [ApiController]
    [Route("books")]
    [Route("authors")]
    [Route("deliverers")]
    [Route("suplliers")]
    [Route("rentals")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationHelper authenticationHelper;

        public AuthenticationController(IAuthenticationHelper authenticationHelper)
        {
            this.authenticationHelper = authenticationHelper;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(PrincipalCreateDTO principal)
        {
            var role = authenticationHelper.AuthenticatePrincipal(principal);
            if ( role != null )
            {
                principal.Role = role;
                var tokenString = authenticationHelper.GenerateJwt(principal);
                return Ok(new { token = tokenString });
            }
            
            return Unauthorized();
        }

    }
}
