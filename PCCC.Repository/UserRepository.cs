using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PCCC.Common.DTOs.Users;
using PCCC.Common.Utils;
using PCCC.Data;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;

namespace APIProject.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PCCC.Data.PcccContext dbContext) : base(dbContext)
        {

        }

        public async Task<IPagedList<UserModel>> GetUsers(int page, int limit, string SearchKey, int? role, int? status, string fromDate, string toDate)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var fd = Util.ConvertFromDate(fromDate);
                    var td = Util.ConvertToDate(toDate);
                    var model = (from u in DbContext.Users
                                 where u.IsActive.Equals(PCCCConsts.ACTIVE)
                                 && (!string.IsNullOrEmpty(SearchKey) ? (u.UserName.Contains(SearchKey) || u.Phone.Contains(SearchKey)) : true)
                                 && (status.HasValue ? u.IsActive.Equals(status) : true)
                                 select new UserModel
                                 {
                                     ID = u.Id,
                                     Email = u.Email,
                                     Phone = u.Phone,
                                     Username = u.UserName,
                                     Status = u.IsActive,
                                     CreatedDate = u.CreationTime,
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
