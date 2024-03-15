using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.Roles
{
    public class UpdateRoleModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public string DisplayName { get; set; }

        public string? Note { get; set; }

        public bool IsActive { get; set; }
    }
}
