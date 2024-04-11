using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PCCC.Common.DTOs.Roles;
using PCCC.Common.DTOs.UpgradeAccs;
using PCCC.Common.DTOs.Users;
using PCCC.Common.Utils;
using PCCC.Data;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;

namespace PCCC.Repository
{
    public class UpgradeAccRepository : BaseRepository<UpgradeAccount>, IUpgradeAccRepository
    {
        public UpgradeAccRepository(PcccContext dbContext) : base(dbContext)
        {
        }

        public async Task<IPagedList<UpgradeAccModel>> GetUpgrateAccs(UpgradeAccSearchPageResult param)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var fd = Util.ConvertFromDate(param.fromDate);
                    var td = Util.ConvertToDate(param.toDate);
                    var model = (from u in DbContext.UpgradeAccounts
                                 where (!string.IsNullOrEmpty(param.SearchKey) ? (u.Name.Contains(param.SearchKey)) : true
                                 && param.IsActive.HasValue ? u.IsActive.Equals(param.IsActive) : true)
                                 select new UpgradeAccModel
                                 {
                                     Id = u.Id,
                                     Name = u.Name,
                                     Description = u.Description,
                                     Price = u.Price,
                                     Type = u.Type,
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
