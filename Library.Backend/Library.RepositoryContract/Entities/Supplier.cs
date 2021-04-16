using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.RepositoryContract.Entities
{
    public class Supplier
    {
        [Key]
        public Guid SupplierID { get; set; }
        public String CompanyName { get; set; }
        public int SupplierContant { get; set; }
        public string SupplierAddress { get; set; }
    }
}
