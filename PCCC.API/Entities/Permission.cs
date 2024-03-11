﻿using System;
using System.Collections.Generic;

namespace PCCC.API.Entities;

public partial class Permission
{
    public int Id { get; set; }

    public long RoleId { get; set; }

    public string Name { get; set; } = null!;

    public long UserId { get; set; }
}
