using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.ServiceContract.DTOs.CreateDTO
{
    public class RentalCreateDTO
    {
		public Guid BookID { get; set; }
		public Guid UserID { get; set; }
		public Guid EmployeeID { get; set; }
		public Guid DeliveryID { get; set; }
	}
}
