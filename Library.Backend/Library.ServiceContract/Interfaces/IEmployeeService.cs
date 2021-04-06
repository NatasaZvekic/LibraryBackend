using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeReadDTO> GetAllEmployees();

        EmployeeReadDTO GetEmployeeByID(Guid employeeID);

        Guid AddNewEmployee(EmployeeCreateDTO employee);

        void UpdateEmployee(EmployeeUpdateDTO employee, Guid empployeeID);

        bool DeleteEmployee(Guid employeeID);
    }
}
