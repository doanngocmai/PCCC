using System;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class ApartmentUser
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public int BuildingId { get; set; }

    public DateTime CreationTime { get; set; }

    public int? AreaId { get; set; }

    public int? MapId { get; set; }

    public string FloorNumber { get; set; } = null!;
}
