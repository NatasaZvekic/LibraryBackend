﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.DTOs.UpdateDTO
{
    public class UserUpdateDTO
    {
        public String UserName { get; set; }
        public String UserLastName { get; set; }
        public String UserAddress { get; set; }
        public int UserContact { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
