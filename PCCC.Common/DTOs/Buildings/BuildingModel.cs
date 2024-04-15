using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.Buildings
{
    public class BuildingModel
    {
        public string Address { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int FloorCount { get; set; }

        public string? Image { get; set; }

        public int? ApartmentUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public int Id { get; set; }
    }
}
