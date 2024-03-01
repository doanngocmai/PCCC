using System;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class UserRole
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long RoleId { get; set; }

    public DateOnly CreationTime { get; set; }
}
