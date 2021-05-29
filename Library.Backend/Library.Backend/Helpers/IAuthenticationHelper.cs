using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Backend.Helpers
{
    public interface IAuthenticationHelper
    {
        public PrincipalReadDTO AuthenticatePrincipal(PrincipalCreateDTO principal);
        public string GenerateJwt(PrincipalCreateDTO principal);
    }
}
