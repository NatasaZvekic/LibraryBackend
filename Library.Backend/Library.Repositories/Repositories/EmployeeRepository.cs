using AutoMapper;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;

        public EmployeeRepository(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<Employee> GetAllEmployees()
        {
            return mapper.Map<List<Employee>>(context.Employee.ToList());
        }

    }
}
