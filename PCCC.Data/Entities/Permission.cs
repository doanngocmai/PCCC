using System;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class Permission
{
    public int Id { get; set; }

    public long RoleId { get; set; }

    public string Name { get; set; } = null!;

    public long UserId { get; set; }
}
