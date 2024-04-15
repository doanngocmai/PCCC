using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.Buildings
{
    public class UpdateBuildingModel
    {
        public string Address { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int FloorCount { get; set; }
        public string? Image { get; set; }
        public int Id { get; set; }
        public bool? IsActive { get; set; }
        public string? Note { get; set; }
    }
}
