using Library.ServiceContract.DTOs.CreateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Backend.Helpers
{
    public interface IAuthenticationHelper
    {
        public String AuthenticatePrincipal(PrincipalCreateDTO principal);
        public string GenerateJwt(PrincipalCreateDTO principal);
    }
}
