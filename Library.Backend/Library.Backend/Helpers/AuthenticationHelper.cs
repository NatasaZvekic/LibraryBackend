using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Library.Backend.Helpers
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private readonly IConfiguration configuration;
        private readonly IUserService userService;

        public AuthenticationHelper(IConfiguration configuration, IUserService userService)
        {
            this.configuration = configuration;
            this.userService = userService;
        }


        public PrincipalReadDTO AuthenticatePrincipal(PrincipalCreateDTO principal)
        {
            try
            {
                var prin = userService.UserWithCredentialsExists(principal.Email, principal.Password);
                return prin;
            }
            catch (Exception)
            {
                throw new Exception("not found");
            }
        }

        public string GenerateJwt(PrincipalCreateDTO principal)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claims = new[]
            {
                new Claim(ClaimTypes.Role, principal.Role)
            };
            
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                                             configuration["Jwt:Issuer"],
                                             claims: claims,
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
