using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

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
       
        public List<Book> GetAllBooks( String bookName = null)
        {

            List<BookWithAuthor> result =  RawSqlQuery("SELECT BookID, BookName, PublishYear, Url, Available, AuthorName, AuthorLastName, SupllierID, GenreID, a.AuthorID FROM Books b"
                    + " INNER JOIN Author a on a.AuthorID = b.AuthorID",
                    x => new BookWithAuthor { BookID= (Guid)x[0], BookName = (string)x[1], PublishYear = (int)x[2], Url = (String)x[3], Available = (int)x[4] , AuthorName = (String)x[5] ,
                        AuthorLastName = (String)x[6], SupllierID = (Guid)x[7], GenreID = (Guid)x[8], AuthorID = (Guid)x[9] });

             return mapper.Map<List<Book>>(result.Where(e => string.IsNullOrEmpty(bookName) || e.BookName.Contains(bookName)));
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
            oldBook.Url = book.Url;

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

         public  List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
         {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();

                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }

                    return entities;
                }
            }
         }
       
    }
}
