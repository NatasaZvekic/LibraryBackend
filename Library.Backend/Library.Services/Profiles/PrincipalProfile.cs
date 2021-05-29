using AutoMapper;
using Library.RepositoryContract.Entities;
using Library.ServiceContract.DTOs.ReadDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Profiles
{
    public class PrincipalProfile : Profile
    {
        public PrincipalProfile()
        {
            CreateMap<Principal, PrincipalReadDTO>();
        }
           
        }

}
