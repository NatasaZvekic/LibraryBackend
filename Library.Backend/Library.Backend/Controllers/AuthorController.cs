using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.RepositoryContract.Entities;
using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Library.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;

namespace Library.Backend.Controllers
{
    [ApiController]
    [Route("/authors")]
    [Authorize(Roles = "admin")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;
        private readonly LinkGenerator linkGenerator;
        public AuthorController(IAuthorService authorService, LinkGenerator linkGenerator)
        {
            this.authorService = authorService;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<AuthorReadDTO>> GetAllAuthors()
        {
            var authors = authorService.GetAllAuthors();
            if (authors == null)
            {
                return NoContent();
            }
            return Ok(authors);
        }

        [HttpGet("{authorID}")]
        public ActionResult GetAuthorByID(Guid authorID)
        {
            var author = authorService.GetAuthorByID(authorID);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public ActionResult AddNewAuthor(AuthorCreateDTO author)
        {
            var guid = authorService.AddNewAuthor(author);

            string location = linkGenerator.GetPathByAction("GetAuthorByID", "Author", new { authorID = guid });
            return Created(location, guid);
        }

        [HttpPut("{authorID}")]
        public IActionResult UpdateAuthor(AuthorUpdateDTO author, Guid authorID)
        {
            try
            {
                authorService.UpdateAuthor(author, authorID);

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpDelete("{authorID}")]
        public IActionResult DeleteAuthor(Guid authorID)
        {
            bool deleted = authorService.DeleteAuthor(authorID);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
