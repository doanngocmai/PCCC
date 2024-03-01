﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PCCC.Common.DTOs.Authentications
{
    public class PhoneModel
    {
        public string Phone { get; set; }
    }

    public class RegisterPhone
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DeviceID { get; set; }
        public int Role { get; set; }
        public int IdToken { get; set; }
    }
}
