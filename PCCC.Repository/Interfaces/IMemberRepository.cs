using PagedList.Core;
using PCCC.Common.DTOs.Users;
using PCCC.Data.Entities;

namespace PCCC.Repository.Interfaces
{
    public interface IMemberRepository : IRepository<User>
    {
        Task<IPagedList<UserModel>> GetMembers(UserSearchPageResults param);
    }


}
