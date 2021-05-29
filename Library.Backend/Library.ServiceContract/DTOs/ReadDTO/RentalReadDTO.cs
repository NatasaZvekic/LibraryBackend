using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.ServiceContract.DTOs.ReadDTO
{
    public class RentalReadDTO
    {
		[Key]
		public Guid RentalID { get; set; }
		public DateTime RentalDate { get; set; }
		public Guid BookID { get; set; }
		public Guid UserID { get; set; }
		public Guid EmployeeID { get; set; }
		public Guid DeliveryID { get; set; }
		public String BookName { get; set; }
		public String UserName { get; set; }
		public String EmployeeName { get; set; }
		public String DeliveryCompanyName { get; set; }
	}
}
