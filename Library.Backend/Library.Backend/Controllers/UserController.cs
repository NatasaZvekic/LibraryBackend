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
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly LinkGenerator linkGenerator;
        public UserController(IUserService userService, LinkGenerator linkGenerator)
        {
            this.userService = userService;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult <List<UserReadDTO>> GetAllUsers()
        {
            var users = userService.GetAllUsers();
            if (users == null)
            {
                return NoContent();
            }
            return Ok(users);
        }

        [HttpGet("{userID}")]
        [Authorize(Roles = "admin")]
        public ActionResult GetUserByID(Guid userID)
        {
            var user = userService.GetUserByID(userID);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult AddNewUser(UserCreateDTO user)
        {
            try
            {
                var guid = userService.AddNewUser(user);

                string location = linkGenerator.GetPathByAction("GetUserByID", "User", new { userID = guid });
                return Created(location, guid);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{userID}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult UpdateUser(UserUpdateDTO user, Guid userID)
        {
            try
            {
                userService.UpdateUser(user, userID);

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpDelete("{userID}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult DeleteUser(Guid userID)
        {
            bool deleted = userService.DeleteUser(userID);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
