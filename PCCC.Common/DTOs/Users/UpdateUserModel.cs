using System;
using System.Collections.Generic;
using System.Text;

namespace PCCC.Common.DTOs.Users
{
   public class UpdateUserModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }

        public bool Sex { get; set; }

        public string? Address { get; set; }

        public string Password { get; set; } = null!;

        public float Amount { get; set; }

        public int IsActive { get; set; }

        public string UserName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;
        public List<int> listRole { get; set; }
    }
}
