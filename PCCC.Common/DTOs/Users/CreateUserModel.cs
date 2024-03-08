﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PCCC.Common.DTOs.Users
{
   public class CreateUserModel
    {
        public string? FullName { get; set; }

        public bool Sex { get; set; }

        public string? Address { get; set; }

        public string Password { get; set; } = null!;

        public DateTime CreationTime { get; set; }

        public float Amount { get; set; }

        public string CreatorUserName { get; set; } = null!;

        public long? UpgradeAccId { get; set; }

        public long? BuildingId { get; set; }

        public long? ApartmentUserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
