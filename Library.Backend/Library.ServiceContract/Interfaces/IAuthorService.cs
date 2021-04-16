using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorReadDTO> GetAllAuthors();
        AuthorReadDTO GetAuthorByID(Guid authorID);
        Guid AddNewAuthor(AuthorCreateDTO author);
        void UpdateAuthor(AuthorUpdateDTO author, Guid authorID);
        bool DeleteAuthor(Guid authorID);
    }
}
