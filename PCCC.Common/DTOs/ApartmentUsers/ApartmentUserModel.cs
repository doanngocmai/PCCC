using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.ApartmentUsers
{
    public class ApartmentUserModel
    {
        public int Id { get; set; }

        public string Address { get; set; } = null!;

        public int BuildingId { get; set; }

        public DateTime CreationTime { get; set; }

        public int? AreaId { get; set; }

        public int? MapId { get; set; }

        public string FloorNumber { get; set; } = null!;
    }
}
