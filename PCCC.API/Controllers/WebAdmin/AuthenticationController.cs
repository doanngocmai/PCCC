using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using PCCC.Service.Services;
using PCCC.Common.Utils;
using Microsoft.AspNetCore.Authorization;
using PCCC.Common.DTOs.Users;
using PCCC.Common.DTOs.Authentications;
using PCCC.Data.Entities;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/web/[controller]")]
    [ApiExplorerSettings(GroupName = "WebAdmin")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IConfiguration _Configuration;
        private readonly IUserService _userService;
        private readonly string secretKey;
        private readonly int timeout;

        public AuthenticationController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _Configuration = configuration;
            try
            {
                secretKey = _Configuration["Authentication:Secret"];
                timeout = int.Parse(_Configuration["Time:timeout"]);
            }
            catch
            {
                secretKey = String.Empty;
                timeout = 5;
            }
        }

        /// <summary>
        /// Đăng nhập cho Admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// </remarks>
        [HttpPost("Login")]
        public async Task<JsonResultModel> Login(LoginModel model)
        {
            return await _userService.Authenticate(model, secretKey, timeout);
        }
        ///// <summary>
        ///// Đổi mật khẩu
        ///// </summary>
        ///// <returns></returns>
        //[Authorize]
        //[HttpPost("ChangePassword")]
        //public async Task<JsonResultModel> ChangePassword(ChangePasswordWebModel model)
        //{
        //    var user = (User)HttpContext.Items["Payload"];
        //    return await _userService.ChangePassword(user.Id, model.OldPassword, model.NewPassword);
        //}
        ///// <summary>
        ///// Thông tin tài khoản
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("GetUserInfo")]
        //[Authorize]
        //public async Task<JsonResultModel> GetUserInfo()
        //{
        //    var user = (User)HttpContext.Items["Payload"];
        //    return await _userService.GetUserInfo(user.ID);
        //}
    }
}
