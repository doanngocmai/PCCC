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

        public async Task<IPagedList<RoleModel>> GetRoles(RoleSearchPageResults param)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var fd = Util.ConvertFromDate(param.fromDate);
                    var td = Util.ConvertToDate(param.toDate);
                    var model = (from u in DbContext.Roles
                                 where (!string.IsNullOrEmpty(param.SearchKey) ? (u.RoleName.Contains(param.SearchKey) || u.DisplayName.Contains(param.SearchKey)) : true
                                 && param.IsActive.HasValue ? u.IsActive.Equals(param.IsActive) : true)
                                 select new RoleModel
                                 {
                                     Id = u.Id,
                                     RoleName = u.RoleName,
                                     DisplayName = u.DisplayName,
                                     Note = u.Note,
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
