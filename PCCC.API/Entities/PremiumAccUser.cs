using System;
using System.Collections.Generic;

namespace PCCC.API.Entities;

public partial class PremiumAccUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AdsId { get; set; }

    public DateTime CreationTime { get; set; }
}
