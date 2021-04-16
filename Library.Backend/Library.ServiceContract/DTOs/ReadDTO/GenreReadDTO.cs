using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.ServiceContract.DTOs.ReadDTO
{
    public class GenreReadDTO
    {
        [Key]
        public Guid GenreID { get; set; }
        public String GenreName { get; set; }
    }
}
