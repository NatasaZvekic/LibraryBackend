using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.DTOs.ReadDTO
{
    public class PrincipalReadDTO
    {
        public String Email { get; set; }
        public String Password { get; set; }
        public String Salt { get; set; }
        public String Role { get; set; }
        public Guid UserID { get; set; }
        public String UserName { get; set; }
        public String UserLastName { get; set; }
    }
}
