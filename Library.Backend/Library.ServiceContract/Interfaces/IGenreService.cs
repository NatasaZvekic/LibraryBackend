using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.Interfaces
{
    public interface IGenreService
    {
        List<GenreReadDTO> GetAllGenres();
        GenreReadDTO GetGenreByID(Guid genreID);
        Guid AddNewGenre(GenreCreateDTO genre);
        void UpdateGenre(GenreUpdateDTO genre, Guid genreID);
        bool DeleteGenre(Guid genreID);
    }
}
