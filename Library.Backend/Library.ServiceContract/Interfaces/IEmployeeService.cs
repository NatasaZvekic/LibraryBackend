using Library.ServiceContract.DTOs.ReadDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeReadDTO> GetAllEmployees();

    }
}
