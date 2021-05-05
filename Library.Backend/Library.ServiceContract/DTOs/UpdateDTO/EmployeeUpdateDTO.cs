using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.DTOs.UpdateDTO
{
    public class EmployeeUpdateDTO
    {
        public String EmployeeName { get; set; }
        public String EmployeeLastName { get; set; }
        public int EmployeeContact { get; set; }
        public int SSN { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
    }
}
