using AutoMapper;
using Library.RepositoryContract.Entities;
using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Profiles
{
    public class RentalProfile : Profile
    {
        public RentalProfile()
        {
            CreateMap<RentalReadDTO, Rental>();
            CreateMap<Rental, RentalReadDTO>();
            CreateMap<RentalCreateDTO, Rental>();
            CreateMap<RentalUpdateDTO, Rental>();

        }
    }
}
