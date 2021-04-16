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
    public class DelivererProfile : Profile
    {
        public DelivererProfile()
        {
            CreateMap<Deliverer, DelivererReadDTO>();
            CreateMap<DelivererCreateDTO, Deliverer>();
            CreateMap<DelivererUpdateDTO, Deliverer>();
        }
    }
}
