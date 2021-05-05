
using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.RepositoryContract.Interfaces
{
    public interface IBookRepository
    {

        List<Book> GetAllBooks( String bookName);
        Book GetBookByID(Guid bookID);
        Guid AddNewBook(Book book);
        void UpdateBook(Book book, Guid bookID);
        bool DeleteBook(Guid bookID);
    }
}
