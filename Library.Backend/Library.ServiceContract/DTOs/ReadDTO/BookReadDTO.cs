using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.ServiceContract.DTOs.ReadDTO
{
    public class BookReadDTO
    {
		[Key]
		public Guid BookID { get; set; }
		public String BookName { get; set; }
		public Guid AuthorID { get; set; }
		public int PublishYear { get; set; }
		public int Available { get; set; }
		public Guid GenreID { get; set; }
		public Guid SupllierID { get; set; }
		public String Url { get; set; }
		public String AuthorName { get; set; }
		public String AuthorLastName { get; set; }
		public int Price { get; set; }

	}
}
