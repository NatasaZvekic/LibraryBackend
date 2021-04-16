using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.DTOs.UpdateDTO
{
    public class AuthorUpdateDTO
    {
        public String AuthorName { get; set; }
        public String AuthorLastName { get; set; }
        public int YearOfBirth { get; set; }
    }
}
