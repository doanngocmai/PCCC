using System;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class Role
{
    public long Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime CreationTime { get; set; }

    public bool IsActive { get; set; }
}
