using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.DTOs.UpdateDTO
{
    public class RentalUpdateDTO
    {

		public DateTime RentalDate { get; set; }
		public Guid BookID { get; set; }
		public Guid UserID { get; set; }
		public Guid EmployeeID { get; set; }
		public Guid DeliveryID { get; set; }
	}
}
