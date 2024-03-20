using PagedList.Core;
using PCCC.Common.DTOs.Users;
using PCCC.Data.Entities;

namespace PCCC.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IPagedList<UserModel>> GetUsers(UserSearchPageResults param);
    }


}
