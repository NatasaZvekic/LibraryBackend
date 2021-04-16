using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.RepositoryContract.Interfaces
{
    public interface ISupplierRepository
    {
        List<Supplier> GetAllSupplier();
        Supplier GetSupplierByID(Guid supplierID);
        Guid AddNewSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier, Guid supplierID);
        bool DeleteSupplier(Guid supplierID);
    }
}
