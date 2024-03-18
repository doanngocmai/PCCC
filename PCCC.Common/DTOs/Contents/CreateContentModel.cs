﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.Contents
{
    public class CreateContentModel
    {
            public string Name { get; set; } = null!;

            public string? Description { get; set; }

            public int Type { get; set; }

            public string? Image { get; set; }

            public string? Link { get; set; }

            public string? Color { get; set; }

            public string? Icon { get; set; }

            public bool IsActive { get; set; }
    }
}
