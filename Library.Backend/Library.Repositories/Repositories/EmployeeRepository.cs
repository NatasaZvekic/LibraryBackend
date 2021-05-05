using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Library.Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;
        private readonly static int iterations = 1000;
        public EmployeeRepository(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<Employee> GetAllEmployees()
        {
            return mapper.Map<List<Employee>>(context.Employee.ToList());
        }

        public Employee GetEmployeeByID(Guid employeeID)
        {
            var employee = context.Employee.FirstOrDefault(e => e.EmployeeID == employeeID);
            return mapper.Map<Employee>(employee);
        }

        public Guid AddNewEmployee(Employee employee)
        {
            var employeeDB = mapper.Map<EmployeeDB>(employee);
            Guid employeeID = Guid.NewGuid();
            employeeDB.EmployeeID = employeeID;

            var pass = HashPassword(employee.Password);
            employeeDB.Salt = pass.Item2;
            employeeDB.Password = pass.Item1;

            context.Employee.Add(employeeDB);
            context.SaveChanges();

            return employeeID;
        }

        public void UpdateEmployee(Employee employee, Guid employeeID)
        {
            var employeeOld = context.Employee.FirstOrDefault(e => e.EmployeeID == employeeID);

            if(employeeOld == null)
            {
                throw new Exception("not found");
            }

            employeeOld.EmployeeName = employee.EmployeeName;
            employeeOld.EmployeeLastName = employee.EmployeeLastName;
            employeeOld.EmployeeContact = employee.EmployeeContact;
            employeeOld.SSN = employee.SSN;

            context.SaveChanges();
        }

        public bool DeleteEmployee(Guid employeeID)
        {
            var employee = context.Employee.FirstOrDefault(e => e.EmployeeID == employeeID);
            if(employee == null)
            {
                return false;
            }

            context.Employee.Remove(employee);
            context.SaveChanges();
            return true;
        }

        private Tuple<string, string> HashPassword(string password)
        {
            var sBytes = new byte[password.Length];
            new RNGCryptoServiceProvider().GetNonZeroBytes(sBytes);
            var salt = Convert.ToBase64String(sBytes);

            var derivedBytes = new Rfc2898DeriveBytes(password, sBytes, iterations);

            return new Tuple<string, string>
            (
                Convert.ToBase64String(derivedBytes.GetBytes(256)),
                salt
            );
        }

    }
}
