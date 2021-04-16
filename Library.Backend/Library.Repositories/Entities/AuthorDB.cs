using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Repositories.Entities
{
    public class AuthorDB
    {
        [Key]
        public Guid AuthorID { get; set; }
        public String AuthorName { get; set; }
        public String AuthorLastName { get; set; }
        public int YearOfBirth { get; set; }
    }
}
