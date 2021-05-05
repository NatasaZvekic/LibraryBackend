using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Library.Repositories.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;

        public GenreRepository(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<Genre> GetAllGenres()
        {
            return mapper.Map<List<Genre>>(context.Genre);
        }

        public Genre GetGenreByID(Guid genreID)
        { 

           // var name = new SqlParameter("@Name", "Drama");
            //var genre = context.Genre.FromSqlRaw("select * from Genre where GenreName=@Name", name).FirstOrDefault();
            var genre = context.Genre.FirstOrDefault(e => e.GenreID == genreID);
            return mapper.Map<Genre>(genre);
        }
        public Guid AddNewGenre(Genre genre)
        {
            var genreDB = mapper.Map<GenreDB>(genre);
            Guid genreID = Guid.NewGuid();
            genreDB.GenreID = genreID;

            context.Genre.Add(genreDB);
            context.SaveChanges();

            return genreID;
        }

        public void UpdateGenre(Genre genre, Guid genreID)
        { 
            var oldGenre = context.Genre.FirstOrDefault(e => e.GenreID == genreID);

            if (oldGenre == null)
            {
                throw new Exception("not found");
            }

            oldGenre.GenreName = genre.GenreName;

            context.SaveChanges();
        }
        public bool DeleteGenre(Guid genreID)
        {
            var genre = context.Genre.FirstOrDefault(e => e.GenreID == genreID);
            if (genre == null)
            {
                return false;
            }

            context.Genre.Remove(genre);

            context.SaveChanges();
            return true;
        }
    }
}
