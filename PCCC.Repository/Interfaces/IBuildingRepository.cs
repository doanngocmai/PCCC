using PagedList.Core;
using PCCC.Common.DTOs.Buildings;
using PCCC.Data.Entities;

namespace PCCC.Repository.Interfaces
{
    public interface IBuildingRepository : IRepository<Building>
    {
        Task<IPagedList<BuildingModel>> GetBuildings(BuildingSearchPageResults param);
    }
}
