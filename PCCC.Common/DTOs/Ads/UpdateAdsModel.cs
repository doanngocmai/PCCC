using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.Ads
{
    public class UpdateAdsModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Content { get; set; }

        public int Type { get; set; }

        public float Price { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsActive { get; set; }
    }
}
