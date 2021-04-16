using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.RepositoryContract.Interfaces
{
    public interface IGenreRepository
    {
        List<Genre> GetAllGenres();
        Genre GetGenreByID(Guid genreID);
        Guid AddNewGenre(Genre genre);
        void UpdateGenre(Genre genre, Guid genreID);
        bool DeleteGenre(Guid genreID);
    }
}
