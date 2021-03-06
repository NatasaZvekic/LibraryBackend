using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Repositories.Entities
{
   public class PrincipalDB
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
