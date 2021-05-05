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
            try
            {
                var role = authenticationHelper.AuthenticatePrincipal(principal);
              
                principal.Role = role;
                var tokenString = authenticationHelper.GenerateJwt(principal);
                return Ok(new { token = tokenString, role = principal.Role });
            }
            catch{
                return Unauthorized(); 
            }
        }

    }
}
