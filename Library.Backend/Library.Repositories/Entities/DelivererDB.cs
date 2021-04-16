using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Repositories.Entities
{
    public class DelivererDB
    {
        [Key]
        public Guid DeliveryID { get; set; }
        public String DeliveryCompanyName { get; set; }
        public int DeliveryContant { get; set; }
        public String DeliveryAddress { get; set; }
    }
}
