using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Library.ServiceContract.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Backend.Controllers
{

    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly LinkGenerator linkGenerator;
        public BookController(IBookService bookService, LinkGenerator linkGenerator)
        {
            this.bookService = bookService;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<BookReadDTO>> GetAllBooks(int pageNumber, String bookName)
        {

            var books = bookService.GetAllBooks(bookName);
            if (bookName != null) { pageNumber = 0; }
            
            var content = new { BooksList = books.Skip(5 * (pageNumber - 1)).Take(5), NumberOfPages = (int)Math.Round((Decimal)books.Count / 5, 0, MidpointRounding.ToPositiveInfinity) };
           

            if (books == null)
            {
                return NoContent();
            }
            return Ok(content);
        }

        [HttpGet("{bookID}")]
        public ActionResult GetBookByID(Guid bookID)
        {
            var book = bookService.GetBookByID(bookID);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddNewBook(BookCreateDTO book)
        {
            var guid = bookService.AddNewBook(book);

            string location = linkGenerator.GetPathByAction("GetBookByID", "Book", new { bookID = guid });
            return Created(location, guid);
        }

        [HttpPut("{bookID}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateBook(BookUpdateDTO book, Guid bookID)
        {
            try
            {
                bookService.UpdateBook(book, bookID);

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{bookID}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteBook(Guid bookID)
        {
            bool deleted = bookService.DeleteBook(bookID);

            if (deleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
