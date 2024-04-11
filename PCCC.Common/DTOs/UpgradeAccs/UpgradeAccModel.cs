using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.UpgradeAccs
{
    public class UpgradeAccModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public float Price { get; set; }

        public int Type { get; set; }

        public string? Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsActive { get; set; }
    }
}
