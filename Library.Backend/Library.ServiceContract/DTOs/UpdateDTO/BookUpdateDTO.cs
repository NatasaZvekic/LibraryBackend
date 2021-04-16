using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.DTOs.UpdateDTO
{
    public class BookUpdateDTO
    {
		public String BookName { get; set; }
		public Guid AuthorID { get; set; }
		public int PublishYear { get; set; }
		public int Available { get; set; }
		public Guid GenreID { get; set; }
		public Guid SupllierID { get; set; }
	}
}
