using System;
using System.Collections.Generic;

namespace PCCC.Data.Entities;

public partial class Content
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Type { get; set; }

    public string? Image { get; set; }

    public string? Link { get; set; }

    public string? Color { get; set; }

    public string? Icon { get; set; }

    public DateTime CreationTime { get; set; }

    public bool IsActive { get; set; }
}
