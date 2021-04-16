using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.ServiceContract.DTOs.ReadDTO
{
    public class DelivererReadDTO
    {
        [Key]
        public Guid DeliveryID { get; set; }
        public String DeliveryCompanyName { get; set; }
        public int DeliveryContant { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
