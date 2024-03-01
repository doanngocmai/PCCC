using System;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class PremiumAccUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AdsId { get; set; }

    public DateOnly CreationTime { get; set; }
}
