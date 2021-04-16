using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Library.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Backend.Controllers
{
    [ApiController]
    [Route("/genres")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;
        private readonly LinkGenerator linkGenerator;
        public GenreController(IGenreService genreService, LinkGenerator linkGenerator)
        {
            this.genreService = genreService;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<GenreReadDTO>> GetAllGenres()
        {
            var genres = genreService.GetAllGenres();
            if (genres == null)
            {
                return NoContent();
            }
            return Ok(genres);
        }

        [HttpGet("{genreID}")]
        public ActionResult GetGenreByID(Guid genreID)
        {
            var genre = genreService.GetGenreByID(genreID);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public IActionResult AddNewGenre(GenreCreateDTO genre)
        {
            var guid = genreService.AddNewGenre(genre);

            string location = linkGenerator.GetPathByAction("GetGenreByID", "Genre", new { genreID = guid });
            return Created(location, guid);
        }

        [HttpPut("{genreID}")]
        public IActionResult UpdateGenre(GenreUpdateDTO genre, Guid genreID)
        {
            try
            {
                genreService.UpdateGenre(genre, genreID);

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{genreID}")]
        public IActionResult DeleteGenre(Guid genreID)
        {
            bool deleted = genreService.DeleteGenre(genreID);

            if (deleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
