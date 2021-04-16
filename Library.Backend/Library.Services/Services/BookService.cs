using AutoMapper;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Library.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.bookRepository = bookRepository;
        }
        public List<BookReadDTO> GetAllBooks(int pageNumber, String bookName)
        {
            return mapper.Map<List<BookReadDTO>>(bookRepository.GetAllBooks(pageNumber, bookName));
        }

        public BookReadDTO GetBookByID(Guid bookID)
        {
            return mapper.Map<BookReadDTO>(bookRepository.GetBookByID(bookID));
        }

        public Guid AddNewBook(BookCreateDTO book)
        {
            return bookRepository.AddNewBook(mapper.Map<Book>(book));
        }

        public void UpdateBook(BookUpdateDTO book, Guid bookID)
        {
            bookRepository.UpdateBook(mapper.Map<Book>(book), bookID);
        }

        public bool DeleteBook(Guid bookID)
        {
            return bookRepository.DeleteBook(bookID);
        }

    }
}
