using System;
using System.Collections;
using System.Collections.Generic;

namespace PCCC.API.Entities;

public partial class Role
{
    public long Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime CreationTime { get; set; }

    public BitArray IsActive { get; set; } = null!;
}
