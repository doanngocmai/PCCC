using System;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class Building
{
    public string Address { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int FloorCount { get; set; }

    public string? Image { get; set; }

    public int? ApartmentUserId { get; set; }

    public DateTime CreationTime { get; set; }

    public int Id { get; set; }

    public float? Latitude { get; set; }

    public float? Longitude { get; set; }
}
