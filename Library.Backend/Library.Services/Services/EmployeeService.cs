using AutoMapper;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using Library.ServiceContract.DTOs.ReadDTO;
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
    }
}
