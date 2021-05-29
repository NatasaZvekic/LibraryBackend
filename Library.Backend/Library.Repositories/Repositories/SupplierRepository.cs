using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Repositories.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {

        private readonly ContextDB context;
        private readonly IMapper mapper;

        public SupplierRepository(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<Supplier> GetAllSupplier()
        {
            return mapper.Map<List<Supplier>>(context.Suppliers.ToList());
        }

        public Supplier GetSupplierByID(Guid supplierID)
        {
            var supplier = context.Suppliers.FirstOrDefault(e => e.SupplierID == supplierID);
            return mapper.Map<Supplier>(supplier);
        }

        public Guid AddNewSupplier(Supplier supplier)
        {
            var newSupplier = mapper.Map<SupplierDB>(supplier);
            var guid = Guid.NewGuid();
            newSupplier.SupplierID = guid;

            context.Suppliers.Add(newSupplier);
            context.SaveChanges();

            return guid;
        }
        public void UpdateSupplier(Supplier supplier, Guid supplierID)
        {
            var oldSupplier = context.Suppliers.FirstOrDefault(e => e.SupplierID == supplierID);

            if (oldSupplier == null)
            {
                throw new Exception("not found");
            }

            oldSupplier.SupplierAddress = supplier.SupplierAddress;
            oldSupplier.SupplierContant = supplier.SupplierContant;
            oldSupplier.CompanyName = supplier.CompanyName;

            context.SaveChanges();
        }
        public bool DeleteSupplier(Guid supplierID)
        {
            var supplier = context.Suppliers.FirstOrDefault(e => e.SupplierID == supplierID);
            if (supplier == null)
            {
                return false;
            }

            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            return true;
        }
    }
}
