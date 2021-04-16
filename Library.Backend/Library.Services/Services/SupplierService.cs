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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }
        public List<SupplierReadDTO> GetAllSuppliers()
        {
            return mapper.Map<List<SupplierReadDTO>>(supplierRepository.GetAllSupplier());
        }

        public SupplierReadDTO GetSupplierByID(Guid supplierID)
        {
            return mapper.Map<SupplierReadDTO>(supplierRepository.GetSupplierByID(supplierID));
        }
        public Guid AddNewSupplier(SupplierCreateDTO supplier)
        {
            return supplierRepository.AddNewSupplier(mapper.Map<Supplier>(supplier));
        }

        public void UpdateSupplier(SupplierUpdateDTO supplier, Guid supplierID)
        {
            supplierRepository.UpdateSupplier(mapper.Map<Supplier>(supplier), supplierID);
        }
        public bool DeleteSupplier(Guid supplierID)
        {
            return supplierRepository.DeleteSupplier(supplierID);
        }
    }
}
