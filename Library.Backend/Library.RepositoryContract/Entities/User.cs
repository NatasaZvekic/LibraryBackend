﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.RepositoryContract.Entities
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public String UserName { get; set; }
        public String UserLastName { get; set; }
        public String UserAddress { get; set; }
        public int UserContact { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}