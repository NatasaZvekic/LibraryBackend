using System;
using System.Collections.Generic;
using System.Text;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Library.ServiceContract.DTOs.CreateDTO;


namespace Library.ServiceContract.Interfaces
{
    public interface ISupplierService
    {
        List<SupplierReadDTO> GetAllSuppliers();
        SupplierReadDTO GetSupplierByID(Guid supplierID);
        Guid AddNewSupplier(SupplierCreateDTO supplier);
        void UpdateSupplier(SupplierUpdateDTO supplier, Guid supplierID);
        bool DeleteSupplier(Guid supplierID);
    }
}
