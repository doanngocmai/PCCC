using System;
using System.Collections.Generic;

namespace PCCC.API.Entities;

public partial class Area
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int PointAreaId { get; set; }
}
