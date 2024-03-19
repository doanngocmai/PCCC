using PagedList.Core;
using PCCC.Common.DTOs.Roles;
using PCCC.Data.Entities;

namespace PCCC.Repository.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<IPagedList<RoleModel>> GetRoles(RoleSearchPageResults param);
    }
}
