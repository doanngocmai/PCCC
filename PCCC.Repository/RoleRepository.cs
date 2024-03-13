using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PCCC.Common.DTOs.Roles;
using PCCC.Common.DTOs.Users;
using PCCC.Common.Utils;
using PCCC.Data;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;

namespace PCCC.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(PCCC.Data.PcccContext dbContext) : base(dbContext)
        {

        }

        public async Task<IPagedList<RoleModel>> GetRoles(int page, int limit, string SearchKey, int? status, string fromDate, string toDate)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var fd = Util.ConvertFromDate(fromDate);
                    var td = Util.ConvertToDate(toDate);
                    var model = (from u in DbContext.Roles
                                 where (!string.IsNullOrEmpty(SearchKey) ? (u.RoleName.Contains(SearchKey) || u.DisplayName.Contains(SearchKey)) : true)
                                 && (status.HasValue ? u.IsActive.Equals(status) : true)
                                 select new RoleModel
                                 {
                                     Id = u.Id,
                                     RoleName = u.RoleName,
                                     DisplayName = u.DisplayName,
                                     Note = u.Note,
                                     IsActive = u.IsActive,
                                     CreationTime = u.CreationTime,

                                 }).AsQueryable().ToPagedList(page, limit);
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
