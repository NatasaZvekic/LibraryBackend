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
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.Backend.Controllers
{
    [ApiController]
    [Route("/rentals")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService rentalsService;
        private readonly LinkGenerator linkGenerator;
        public RentalController(IRentalService rentalsService, LinkGenerator linkGenerator)
        {
            this.rentalsService = rentalsService;
            this.linkGenerator = linkGenerator;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult<List<RentalReadDTO>> GetAllRentals(Boolean completed)
        {
            var rentals = rentalsService.GetAllRentals(completed);
            if (rentals == null)
            {
                return NoContent();
            }
            return Ok(rentals);
        }

        [Authorize(Roles = "user")]
        [HttpGet("{userID}")]
        public ActionResult GetRentalByID(Guid userID)
        {
            var rental = rentalsService.GetRentalByID(userID);
            if (rental == null)
            {
                return NotFound();
            }
            return Ok(rental);
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost]
        public ActionResult AddNewRental(RentalCreateDTO rental)
        {
            try
            {
                var guid = rentalsService.AddNewRental(rental);

                string location = linkGenerator.GetPathByAction("GetRentalByID", "Rental", new { rentalID = guid });
                return Created(location, guid);
            }
            catch (Exception ex)
            {
               // return StatusCode(500);
                return StatusCode(400);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{rentalID}")]
        public IActionResult UpdateRental(RentalUpdateDTO rental, Guid rentalID)
        {
            try
            {
                rentalsService.UpdateRental(rental, rentalID);

                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete("{retalID}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult DeleteRental(Guid retalID)
        {
            bool deleted = rentalsService.DeleteRental(retalID);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
