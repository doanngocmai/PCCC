using PagedList;
using PCCC.Common.DTOs.Users;
using PCCC.Data.Entities;
using PCCC.Repository.Interfaces;

namespace PCCC.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
         //Task<IPagedList<UserModel>> GetUsers(int page, int limit, string SearchKey, int? role, int? status, string fromDate, string toDate);
    }


}
