using PCCC.Common.Utils;
using PCCC.Common.DTOs.Roles;
using PCCC.Data.Entities;
using PCCC.Service.Interfaces;

namespace PCCC.Service.Services
{
    public interface IRoleService : IServices<Role>
    {
        Task<JsonResultModel> CreateRole(CreateRoleModel usermodel);
        Task<JsonResultModel> UpdateRole(UpdateRoleModel model);
        Task<JsonResultModel> DeleteRole(int ID);
        Task<JsonResultModel> GetListRole(int page, int limit, string SearchKey, int? status, string fromDate, string toDate);
    }
}
