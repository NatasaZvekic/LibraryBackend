using Library.Backend.Helpers;
using Library.ServiceContract.DTOs.CreateDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
                principal.Role = role.Role;
               // principal.Role = role;
                var tokenString = authenticationHelper.GenerateJwt(principal);
                return Ok(new { token = tokenString, role = role });
            }
            catch(Exception e){
                return Unauthorized(); 
            }
        }
        [HttpGet("verifyToken")]
        public Boolean VerifyToken([FromHeader] String token)
        {
            string stream = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiIsImV4cCI6MTYyMTA5NzE2NSwiaXNzIjoiVVJJUy51bnMuYWMucnMiLCJhdWQiOiJVUklTLnVucy5hYy5ycyJ9.XgETFgjj_HxLXlOI8zTVPkkg0InFT9Bsqdx32sx_2z0";
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token.ToString());
            var tokenS = jsonToken as JwtSecurityToken;

            DateTime exipresTime = UnixTimeStampToDateTime(tokenS.Payload.Exp);
            DateTime currentTime = DateTime.Now;
            int result = DateTime.Compare(exipresTime, currentTime);
            
            if(result < 0 || result == 0)
            {
                return false;
            }
            return true;
        }
        private DateTime UnixTimeStampToDateTime(int? unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 2, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds((double)unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }

    }
}
