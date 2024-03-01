using Microsoft.AspNetCore.Identity;
using PCCC.Common.DTOs.Authentications;
using PCCC.Common.DTOs.Users;
using PCCC.Common.Utils;

namespace PCCC.Service.Services
{
    public interface IUserService
    {
        Task<JsonResultModel> Authenticate(LoginModel model, string secretKey, int timeout);
        //Task<JsonResultModel> CreateUser(CreateUserModel usermodel);
        //Task<JsonResultModel> ChangeStatus(int ID);
        //Task<JsonResultModel> ResetPassword(int ID);
        //Task<JsonResultModel> UpdateUser(UpdateUserModel model);
        //Task<JsonResultModel> UpdateDetailUser(int id, UpdateUserModelNew input);
        //Task<JsonResultModel> ChangePassword(int id, string oldPass, string newPass);
        //Task<JsonResultModel> DeleteUser(int ID);
        //Task<JsonResultModel> GetUserDetail(int ID);
        //Task<JsonResultModel> GetUserInfo(int ID);
        //Task<JsonResultModel> GetListUser(int page, int limit, string SearchKey, int? role, int? status, string fromDate, string toDate);
    }
}
