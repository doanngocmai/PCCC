using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.Contents
{
    public class ContentModel
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
}
