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

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.authorRepository = authorRepository;
        }
        public List<AuthorReadDTO> GetAllAuthors()
        {
            return mapper.Map<List<AuthorReadDTO>>(authorRepository.GetAllAuthors());
        }

        public AuthorReadDTO GetAuthorByID(Guid authorID)
        {
            return mapper.Map<AuthorReadDTO>(authorRepository.GetAuthorByID(authorID));
        }
        public Guid AddNewAuthor(AuthorCreateDTO author)
        {
            return authorRepository.AddNewAuthor(mapper.Map<Author>(author));
        }

        public void UpdateAuthor(AuthorUpdateDTO author, Guid authorID)
        {
            authorRepository.UpdateAuthor(mapper.Map<Author>(author), authorID);
        }
        public bool DeleteAuthor(Guid authorID)
        {
            return authorRepository.DeleteAuthor(authorID);
        }

      
    }
}
