﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PCCC.Common.DTOs.Users
{
   public class UserDetailModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string  Phone { get; set; }
        public string  Email { get; set; }
        public string Address { get; set; }
        public string  Password { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }
    }
}
 