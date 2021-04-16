using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.RepositoryContract.Entities
{
    public class Genre
    {
        [Key]
        public Guid GenreID { get; set; }
        public String GenreName { get; set; }
    }
}
