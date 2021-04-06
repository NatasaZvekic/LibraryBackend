using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.RepositoryContract.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();

        Employee GetEmployeeByID(Guid employeeID);

        Guid AddNewEmployee(Employee employee);

        void UpdateEmployee(Employee employee, Guid employeeID);

        bool DeleteEmployee(Guid employeeID);
    }
}
