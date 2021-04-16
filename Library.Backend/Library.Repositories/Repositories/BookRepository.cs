using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Repositories.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;

        public BookRepository(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<Book> GetAllBooks(int pageNumber, String bookName = null)
        {

            if (pageNumber == 0) { pageNumber = 1; }

            if (bookName == null)
            {
                return mapper.Map<List<Book>>(context.Books.Skip(5 * (pageNumber - 1)).Take(5).Where(e => string.IsNullOrEmpty(bookName) || e.BookName.Contains(bookName)));
            }
            else
                return mapper.Map<List<Book>>(context.Books.Where(e => e.BookName.Contains(bookName)));

        }
        public Book GetBookByID(Guid bookID)
        {
            var book = context.Books.FirstOrDefault(e => e.BookID == bookID);
            return mapper.Map<Book>(book);
        }

        public Guid AddNewBook(Book book)
        {
            var bookDB = mapper.Map<BookDB>(book);
            Guid bookID = Guid.NewGuid();
            bookDB.BookID = bookID;

            context.Books.Add(bookDB);
            context.SaveChanges();

            return bookID;
        }

        public void UpdateBook(Book book, Guid bookID)
        {
            var oldBook = context.Books.FirstOrDefault(e => e.BookID == bookID);

            if (oldBook == null)
            {
                throw new Exception("not found");
            }

            oldBook.BookName= book.BookName;
            oldBook.AuthorID = book.AuthorID;
            oldBook.Available = book.Available;
            oldBook.GenreID = book.GenreID;
            oldBook.PublishYear = book.PublishYear;
            oldBook.SupllierID = book.SupllierID;

            context.SaveChanges();
        }

        public bool DeleteBook(Guid bookID)
        {
            var book = context.Books.FirstOrDefault(e => e.BookID == bookID);
            if (book == null)
            {
                return false;
            }

            context.Books.Remove(book);
            context.SaveChanges();
            return true;
        }

       
    }
}
