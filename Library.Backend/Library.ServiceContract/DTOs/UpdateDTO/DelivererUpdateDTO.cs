using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.ServiceContract.DTOs.UpdateDTO
{
    public class DelivererUpdateDTO
    {
        [Key]
        public Guid DelivererID { get; set; }
        public String DeliveryCompanyName { get; set; }
        public int DeliveryContant { get; set; }
        public String DeliveryAddress { get; set; }
    }
}
