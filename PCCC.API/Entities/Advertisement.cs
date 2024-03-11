using System;
using System.Collections;
using System.Collections.Generic;

namespace PCCC.API.Entities;

public partial class Advertisement
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Content { get; set; }

    public int Type { get; set; }

    public float Price { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public BitArray IsActive { get; set; } = null!;

    public DateTime CreationTime { get; set; }
}
