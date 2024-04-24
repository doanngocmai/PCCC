using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.ApartmentUsers
{
    public class UpdateApartmentUserModel
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;

        public int BuildingId { get; set; }

        public int? AreaId { get; set; }

        public int? MapId { get; set; }

        public string FloorNumber { get; set; } = null!;

        public string? Name { get; set; }
    }
}
