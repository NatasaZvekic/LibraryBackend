using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.Interfaces
{
    public interface IBookService
    {
        List<BookReadDTO> GetAllBooks(String bookName);
        BookReadDTO GetBookByID(Guid bookID);
        Guid AddNewBook(BookCreateDTO book);
        void UpdateBook(BookUpdateDTO book, Guid bookID);
        bool DeleteBook(Guid bookID);
    }
}
