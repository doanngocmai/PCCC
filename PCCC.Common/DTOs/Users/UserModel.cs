using System;
using System.Collections.Generic;
using System.Text;

namespace PCCC.Common.DTOs.Users
{
    public class UserModel
    {
        public long Id { get; set; }

        public string? FullName { get; set; }

        public bool Sex { get; set; }

        public string? Address { get; set; }

        public string Password { get; set; } = null!;

        public int IsActive { get; set; }

        public int Level { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsDelete { get; set; }

        public float Amount { get; set; }

        public string CreatorUserName { get; set; } = null!;

        public long? UpgradeAccId { get; set; }

        public long? BuildingId { get; set; }

        public long? ApartmentUserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
    public class UserInfoModel
    {
        public int ID { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public int Status { get; set; }
        public List<int> ListPermission { get; set; }
    }
}
