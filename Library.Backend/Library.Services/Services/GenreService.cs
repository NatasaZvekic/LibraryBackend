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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        public List<GenreReadDTO> GetAllGenres()
        {
            return mapper.Map<List<GenreReadDTO>>(genreRepository.GetAllGenres());
        }

        public GenreReadDTO GetGenreByID(Guid genreID)
        {
            return mapper.Map<GenreReadDTO>(genreRepository.GetGenreByID(genreID));
        }
        public Guid AddNewGenre(GenreCreateDTO genre)
        {
            return genreRepository.AddNewGenre(mapper.Map<Genre>(genre));
        }
        public void UpdateGenre(GenreUpdateDTO genre, Guid genreID)
        {
            genreRepository.UpdateGenre(mapper.Map<Genre>(genre), genreID);
        }
        public bool DeleteGenre(Guid genreID)
        {
            return genreRepository.DeleteGenre(genreID);
        }  
    }
}
