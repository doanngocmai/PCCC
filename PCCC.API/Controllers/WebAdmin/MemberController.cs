using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCCC.Common.DTOs.Users;
using PCCC.Common.Utils;
using PCCC.Service.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/web/[controller]")]
    [ApiExplorerSettings(GroupName = "WebAdmin")]
    [ApiController]
    [SwaggerTag("User")]
    public class MemberController : ControllerBase
    {
        private readonly IUserService _userService;
        public MemberController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetListUser")]
        //[Authorize]
        public async Task<JsonResultModel> GetListMember([FromQuery] UserSearchPageResults param)
        {
            return await _userService.GetListUser(param);
        }
        //[Authorize]
        [HttpPost("CreateUser")]
        public async Task<JsonResultModel> CreateUser(CreateUserModel model)
        {
            return await _userService.CreateUser(model);
        }
        [HttpPost("UpdateUser")]
        //[Authorize]
        public async Task<JsonResultModel> UpdateUser(UpdateUserModel input)
        {
            return await _userService.UpdateUser(input);
        }
        [HttpDelete("DeleteUser/{ID}")]
        //[Authorize]
        public async Task<JsonResultModel> DeleteUser(int ID)
        {
            return await _userService.DeleteUser(ID);
        }
    }
}
