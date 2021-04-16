﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Repositories.Entities
{
	public class RentalDB
	{
		[Key]
		public Guid RentalID { get; set; }
		public DateTime RentalDate { get; set; }
		public Guid BookID { get; set; }
		public Guid UserID {get;set; }
		public Guid EmployeeID { get; set; }
		public Guid DeliveryID { get; set; }
	}
}
