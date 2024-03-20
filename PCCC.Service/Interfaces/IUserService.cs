using PCCC.Common.DTOs.Authentications;
using PCCC.Common.DTOs.Users;
using PCCC.Common.Utils;
using PCCC.Data.Entities;
using PCCC.Service.Interfaces;

namespace PCCC.Service.Services
{
    public interface IUserService : IServices<User>
    {
        Task<JsonResultModel> Authenticate(LoginModel model, string secretKey, int timeout);
        Task<JsonResultModel> CreateUser(CreateUserModel usermodel);
        Task<JsonResultModel> UpdateUser(UpdateUserModel model);
        Task<JsonResultModel> DeleteUser(int ID);
        Task<JsonResultModel> GetListUser(UserSearchPageResults param);
    }
}
