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
    [Route("/deliverers")]
    [Authorize(Roles = "admin")]
    public class DelivererController : ControllerBase
    {
        private readonly IDelivererService delivererService;
        private readonly LinkGenerator linkGenerator;
        public DelivererController(IDelivererService delivererService, LinkGenerator linkGenerator)
        {
            this.delivererService = delivererService;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<DelivererReadDTO>> GetAllDeliverers()
        {
            var deliverers = delivererService.GetAllDeliverers();
            if (deliverers == null)
            {
                return NoContent();
            }
            return Ok(deliverers);
        }

        [HttpGet("{delivererID}")]
        public ActionResult GetDelivererByID(Guid delivererID)
        {
            var deliverer = delivererService.GetDelivererByID(delivererID);
            if (deliverer == null)
            {
                return NotFound();
            }
            return Ok(deliverer);
        }

        [HttpPost]
        public IActionResult AddNewDeliverer(DelivererCreateDTO deliverer)
        {
            var guid = delivererService.AddNewDeliverer(deliverer);

            string location = linkGenerator.GetPathByAction("GetDelivererByID", "Deliverer", new { delivererID = guid });
            return Created(location, guid);
        }

        [HttpPut("{delivererID}")]
        public IActionResult UpdateBook(DelivererUpdateDTO deliverer, Guid delivererID)
        {
            try
            {
                delivererService.UpdateDeliverer(deliverer, delivererID);

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{delivererID}")]
        public IActionResult DeleteEmployee(Guid delivererID)
        {
            try
            {
                bool deleted = delivererService.DeleteDelivrer(delivererID);

                if (deleted == false)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
