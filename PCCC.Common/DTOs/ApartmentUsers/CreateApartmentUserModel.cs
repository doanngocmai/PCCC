using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.ApartmentUsers
{
    public class CreateApartmentUserModel
    {
        public string Address { get; set; } = null!;

        public int BuildingId { get; set; }

        public float? Longitude { get; set; }

        public float? Latitude { get; set; }

        public int? AreaId { get; set; }

        public int? MapId { get; set; }

        public string FloorNumber { get; set; } = null!;
    }
}
