using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PCCC.Common.DTOs.Authentications
{
    public class LoginModel
    {
        [Required]
        public string Phone { get; set; }
        public string DeviceID { get; set; }
        public string Password { get; set; }
    }
    public class LoginAppModel
    {
        public string Phone { get; set; }
        public string DeviceID { get; set; }
        public string OTP { get; set; }
    }


}
