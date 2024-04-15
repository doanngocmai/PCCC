using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PCCC.Common.DTOs.Ads;
using PCCC.Common.DTOs.ApartmentUsers;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.Utils;
using PCCC.Data;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;

namespace PCCC.Repository
{
    public class ApartmentUserRepository : BaseRepository<ApartmentUser>, IApartmentUserRepository
    {
        public ApartmentUserRepository(PcccContext dbContext) : base(dbContext)
        {

        }

        public async Task<IPagedList<ApartmentUserModel>> GetApartmentUsers(ApartmentUserSearchPageResults param)
        {
            try
            {
                return await Task.Run(() =>
                {
                var model = (from u in DbContext.ApartmentUsers
                                 select new ApartmentUserModel
                                 {
                                     Id = u.Id,
                                     Address = u.Address,
                                     AreaId = u.AreaId,
                                     BuildingId = u.BuildingId,
                                     FloorNumber = u.FloorNumber,
                                     Latitude = u.Latitude,
                                     Longitude = u.Longitude,
                                     MapId = u.MapId,
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
