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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;

        public AuthorRepository(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<Author> GetAllAuthors()
        {
            return mapper.Map<List<Author>>(context.Author.ToList());
        }

        public Author GetAuthorByID(Guid authorID)
        {
            var author = context.Author.FirstOrDefault(e => e.AuthorID == authorID);
            return mapper.Map<Author>(author);
        }

        public Guid AddNewAuthor(Author author)
        {
            var authorDB = mapper.Map<AuthorDB>(author);
            Guid authorID = Guid.NewGuid();
            authorDB.AuthorID = authorID;

            context.Author.Add(authorDB);
            context.SaveChanges();

            return authorID;
        }

        public void UpdateAuthor(Author author, Guid authorID)
        {
            var oldAuthor = context.Author.FirstOrDefault(e => e.AuthorID == authorID);

            if (oldAuthor == null)
            {
                throw new Exception("not found");
            }

            oldAuthor.AuthorName = author.AuthorName;
            oldAuthor.AuthorLastName = author.AuthorLastName;
            oldAuthor.YearOfBirth = author.YearOfBirth;

            context.SaveChanges();
        }
        public bool DeleteAuthor(Guid authorID)
        {
            var author = context.Author.FirstOrDefault(e => e.AuthorID == authorID);
            if (author == null)
            {
                return false;
            }

            context.Author.Remove(author);
            context.SaveChanges();
            return true;
        } 
    }
}
