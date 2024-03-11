using System;
using System.Collections.Generic;

namespace PCCC.API.Entities;

public partial class UserRole
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long RoleId { get; set; }

    public DateTime CreationTime { get; set; }
}
