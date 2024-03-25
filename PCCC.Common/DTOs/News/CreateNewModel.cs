using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.News
{
    public class CreateNewModel

    {
        public string Title { get; set; } = null!;

        public int Type { get; set; }

        public string Content { get; set; } = null!;

        public string? Image { get; set; }

        public bool IsActive { get; set; }
    }
}
