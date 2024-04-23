using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PCCC.Common.DTOs.Buildings;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.Utils;
using PCCC.Data;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;

namespace PCCC.Repository
{
    public class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(PcccContext dbContext) : base(dbContext)
        {

        }

        public async Task<IPagedList<BuildingModel>> GetBuildings(BuildingSearchPageResults param)
        {
            try
            {
                return await Task.Run(() =>
                {
                var model = (from u in DbContext.Buildings
                             where (!string.IsNullOrEmpty(param.SearchKey) ? u.Name.Contains(param.SearchKey) : true 
                             && param.IsActive.HasValue ? u.IsActive.Equals(param.IsActive) : true)
                                 select new BuildingModel
                                 {
                                     Id = u.Id,
                                     Name = u.Name,
                                     Address = u.Address,
                                     FloorCount = u.FloorCount,
                                     Image = u.Image,
                                     IsActive = u.IsActive,
                                     Note= u.Note,
                                     CreationTime = u.CreationTime,
                                 }).AsQueryable().ToPagedList(param.page, param.perPage);
                    return model;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
