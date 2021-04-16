using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Repositories.Entities
{
    public class GenreDB
    {
        [Key]
        public Guid GenreID { get; set; }
        public String GenreName { get; set; }
    }
}
