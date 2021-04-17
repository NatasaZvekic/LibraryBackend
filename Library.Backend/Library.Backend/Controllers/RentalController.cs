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
        public ActionResult<List<RentalReadDTO>> GetAllRentals()
        {
            var rentals = rentalsService.GetAllRentals();
            if (rentals == null)
            {
                return NoContent();
            }
            return Ok(rentals);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{rentalID}")]
        public ActionResult GetRentalByID(Guid rentalID)
        {
            var rental = rentalsService.GetRentalByID(rentalID);
            if (rental == null)
            {
                return NotFound();
            }
            return Ok(rental);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public ActionResult AddNewRental(RentalCreateDTO rental)
        {
            var guid = rentalsService.AddNewRental(rental);

            string location = linkGenerator.GetPathByAction("GetRentalByID", "Rental", new { rentalID = guid });
            return Created(location, guid);
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
            catch
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
