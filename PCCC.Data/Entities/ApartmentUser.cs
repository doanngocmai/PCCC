using System;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class ApartmentUser
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public int ApartmentId { get; set; }

    public float? Longitude { get; set; }

    public float? Latitude { get; set; }

    public DateOnly CreationTime { get; set; }

    public int AreaId { get; set; }

    public int MapId { get; set; }
}
