using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PCCC.Common.DTOs.Ads;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.Utils;
using PCCC.Data;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;

namespace PCCC.Repository
{
    public class AdvertisingRepository : BaseRepository<Advertisement>, IAdvertisingRepository
    {
        public AdvertisingRepository(PcccContext dbContext) : base(dbContext)
        {

        }

        public async Task<IPagedList<AdsModel>> GetAds(AdsSearchPageResults param)
        {
            try
            {
                return await Task.Run(() =>
                {
                var model = (from u in DbContext.Advertisements
                             where (!string.IsNullOrEmpty(param.SearchKey) ? u.Name.Contains(param.SearchKey) : true && param.IsActive.HasValue ? u.IsActive == param.IsActive : true)
                                 select new AdsModel
                                 {
                                     Id = u.Id,
                                     Name = u.Name,
                                     Type = u.Type,
                                     Price = u.Price,
                                     Content = u.Content,
                                     EndTime = u.EndTime,
                                     StartTime = u.StartTime,
                                     IsActive = u.IsActive,
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
