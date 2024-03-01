﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PCCC.Common.DTOs.Users
{
   public class UpdateUserModel
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        public string Phone { get; set; }
        public string  Email { get; set; }
        public int RoleID { get; set; }
        public int Status { get; set; }
    }

    public class UpdateUserModelNew
    {
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
