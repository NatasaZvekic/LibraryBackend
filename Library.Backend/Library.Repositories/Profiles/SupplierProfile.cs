using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Repositories.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierDB, Supplier>();
            CreateMap<Supplier, SupplierDB>();
        }
    }
}
