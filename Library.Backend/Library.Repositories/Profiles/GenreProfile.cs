using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Repositories.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDB>();
            CreateMap<GenreDB, Genre>();
        }
    }
}
