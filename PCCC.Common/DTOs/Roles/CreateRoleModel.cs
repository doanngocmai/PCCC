using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.Roles
{
    public class CreateRoleModel
    {
        public string RoleName { get; set; } = null!;

        public string DisplayName { get; set; } = null!;

        public string? Note { get; set; }

        public bool IsActive { get; set; }
    }
}
