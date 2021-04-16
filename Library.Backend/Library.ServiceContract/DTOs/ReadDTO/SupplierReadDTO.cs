using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.ServiceContract.DTOs.ReadDTO
{
    public class SupplierReadDTO
    {
        [Key]
        public Guid SupplierID { get; set; }
        public String CompanyName { get; set; }
        public int SupplierContant { get; set; }
        public String SupplierAddress { get; set; }
    }
}
