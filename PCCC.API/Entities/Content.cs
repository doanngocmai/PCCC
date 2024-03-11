﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace PCCC.API.Entities;

public partial class Content
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Content1 { get; set; }

    public int Type { get; set; }

    public string? Image { get; set; }

    public string? Link { get; set; }

    public string? Color { get; set; }

    public string? Icon { get; set; }

    public BitArray IsActive { get; set; } = null!;

    public DateTime CreationTime { get; set; }
}
