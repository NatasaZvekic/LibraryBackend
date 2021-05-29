using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Repositories.Profiles
{
    public class RentalProfile : Profile
    {
        public RentalProfile()
        {
            CreateMap<RentalDB, Rental>();
            CreateMap<Rental, RentalDB>();
            CreateMap<Rental, RentalWithDetails>();
            CreateMap<RentalWithDetails, Rental>();
        }
    }
}
