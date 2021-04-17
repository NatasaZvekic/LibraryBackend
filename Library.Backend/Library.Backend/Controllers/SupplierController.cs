using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Microsoft.AspNetCore.Authorization;

namespace Library.Backend.Controllers
{
    [ApiController]
    [Route("/suppliers")]
    [Authorize(Roles = "admin")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService supplierService;
        private readonly LinkGenerator linkGenerator;
        public SupplierController(ISupplierService supplierService, LinkGenerator linkGenerator)
        {
            this.supplierService = supplierService;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<SupplierReadDTO>> GetAllsuppliers()
        {
            var suppliers = supplierService.GetAllSuppliers();
            if (suppliers == null)
            {
                return NoContent();
            }
            return Ok(suppliers);
        }

        [HttpGet("{supplierID}")]
        public ActionResult GetSupplierByID(Guid supplierID)
        {
            var supplier = supplierService.GetSupplierByID(supplierID);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        [HttpPost]
        public ActionResult AddNewSupplier(SupplierCreateDTO supplier)
        {
            var guid = supplierService.AddNewSupplier(supplier);

            string location = linkGenerator.GetPathByAction("GetSupplierByID", "Supplier", new { supplierID = guid });
            return Created(location, guid);
        }

        [HttpPut("{supplierID}")]
        public IActionResult Updatesupplier(SupplierUpdateDTO supplier, Guid supplierID)
        {
            try
            {
                supplierService.UpdateSupplier(supplier, supplierID);

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpDelete("{supplierID}")]
        public IActionResult Deletesupplier(Guid supplierID)
        {
            bool deleted = supplierService.DeleteSupplier(supplierID);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
