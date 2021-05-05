using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Library.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Backend.Controllers
{
    [ApiController]
    [Route("employees")]
    [Authorize(Roles = "admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;
        private readonly LinkGenerator linkGenerator;
        public EmployeeController(IEmployeeService service, LinkGenerator linkGenerator)
        {
            this.service = service;
            this.linkGenerator = linkGenerator;
        }

       [HttpGet]
       public ActionResult <List<EmployeeReadDTO>> GetAllEmployees()
        {
            var employees = service.GetAllEmployees();
            if(employees == null)
            {
                return NoContent();
            }
            return Ok(employees);
        }

       [HttpGet("{employeeID}")]
       public ActionResult GetEmployeeByID(Guid employeeID)
        {
            var employee = service.GetEmployeeByID(employeeID);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddNewEmployee(EmployeeCreateDTO employee)
        {
            var guid = service.AddNewEmployee(employee);

            string location = linkGenerator.GetPathByAction("GetEmployeeByID", "Employee", new { employeeID = guid });
            return Created(location, guid);
        }

        [HttpPut("{employeeID}")]
        public IActionResult UpdateEmployee(EmployeeUpdateDTO employee, Guid employeeID)
        {
            try
            {
                service.UpdateEmployee(employee, employeeID);

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{employeeID}")]
        public IActionResult DeleteEmployee(Guid employeeID)
        {
            bool deleted = service.DeleteEmployee(employeeID);
            
            if(deleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
