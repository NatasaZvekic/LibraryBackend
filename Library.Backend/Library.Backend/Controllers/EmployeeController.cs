using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Backend.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet]
       public ActionResult <List<EmployeeReadDTO>> GetAllEmployees()
        {
            return service.GetAllEmployees();
        }
    }
}
