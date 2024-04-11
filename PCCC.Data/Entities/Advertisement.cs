using System;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class Advertisement
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Content { get; set; }

    public int Type { get; set; }

    public float Price { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime CreationTime { get; set; }

    public bool IsActive { get; set; }
}
