using AutoMapper;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Library.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;            
        }

        public List<EmployeeReadDTO> GetAllEmployees()
        {
            return mapper.Map<List<EmployeeReadDTO>>(repository.GetAllEmployees());
        }

        public EmployeeReadDTO GetEmployeeByID(Guid employeeID)
        {
            return mapper.Map<EmployeeReadDTO>(repository.GetEmployeeByID(employeeID));
        }

        public Guid AddNewEmployee(EmployeeCreateDTO employee)
        {
            return repository.AddNewEmployee(mapper.Map<Employee>(employee));
        }

        public void UpdateEmployee(EmployeeUpdateDTO employee, Guid empployeeID)
        {
            var employee_repos = mapper.Map<Employee>(employee);
            repository.UpdateEmployee(employee_repos, empployeeID);
        }

        public bool DeleteEmployee(Guid employeeID)
        {
            return repository.DeleteEmployee(employeeID);
        }

      
    }
}
