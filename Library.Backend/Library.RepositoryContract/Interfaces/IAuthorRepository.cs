using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.RepositoryContract.Interfaces
{
    public interface IAuthorRepository
    {
        List<Author> GetAllAuthors();
        Author GetAuthorByID(Guid authorID);
        Guid AddNewAuthor(Author author);
        void UpdateAuthor(Author author, Guid authorID);
        bool DeleteAuthor(Guid authorID);
    }
}
