using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.ServiceContract.DTOs.CreateDTO
{
    public class SupplierCreateDTO
    {
        public String CompanyName { get; set; }
        public int SupplierContant { get; set; }
        public String SupplierAddress { get; set; }
    }
}
