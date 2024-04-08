using PCCC.Common.DTOs.Authentications;
using PCCC.Common.DTOs.Users;
using PCCC.Common.Utils;
using PCCC.Data.Entities;
using PCCC.Service.Interfaces;

namespace PCCC.Service.Services
{
    public interface IMemberService : IServices<User>
    {
        Task<JsonResultModel> Authenticate(LoginModel model, string secretKey, int timeout);
        Task<JsonResultModel> CreateMember(CreateUserModel usermodel);
        Task<JsonResultModel> UpdateMember(UpdateUserModel model);
        Task<JsonResultModel> DeleteMember(int ID);
        Task<JsonResultModel> GetListMember(UserSearchPageResults param);
    }
}
