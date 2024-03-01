using System;
using System.Collections;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class Advertisement
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Content { get; set; }

    public int Type { get; set; }

    public float Price { get; set; }

    public DateOnly StartTime { get; set; }

    public DateOnly EndTime { get; set; }

    public BitArray IsActive { get; set; } = null!;

    public DateOnly CreationTime { get; set; }
}
