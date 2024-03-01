using System;
using System.Collections.Generic;
using System.Text;

namespace PCCC.Common.DTOs.Authentications
{
   public class RegisterModel
    {
        public string Phone { get; set; }
        public string DeviceID { get; set; }
        public string OTP { get; set; }
    }
}
