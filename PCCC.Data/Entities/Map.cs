using System;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class Map
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public float Height { get; set; }

    public float Length { get; set; }

    public float Width { get; set; }

    public int Type { get; set; }

    public string? Image { get; set; }

    public string? Note { get; set; }

    public DateTime CreationTime { get; set; }

    public int FloorNumber { get; set; }

    public int AreaId { get; set; }

    public int BuiildingId { get; set; }
}
