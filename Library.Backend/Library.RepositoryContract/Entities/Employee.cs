using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.RepositoryContract.Entities
{
    public class Employee
    {
        [Key]
        public Guid EmployeeID { get; set; }
        public String EmployeeName { get; set; }
        public String EmployeeLastName { get; set; }
        public int EmployeeContact { get; set; }
        public int SSN { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
    }
}
