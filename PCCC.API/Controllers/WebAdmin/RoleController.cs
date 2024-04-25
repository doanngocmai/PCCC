using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.DTOs.Roles;
using PCCC.Common.DTOs.Users;
using PCCC.Common.Utils;
using PCCC.Service.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/web/[controller]")]
    [ApiExplorerSettings(GroupName = "WebAdmin")]
    [ApiController]
    [SwaggerTag("Role")]
    public class RoleController : ControllerBase
    {
        public readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("GetListRole")]
        //[Authorize]
        public async Task<JsonResultModel> GetListRole([FromQuery] RoleSearchPageResults param)
        {
            return await _roleService.GetListRole(param);
        }
        [HttpPost("CreateRole")]
        public async Task<JsonResultModel> CreateRole(CreateRoleModel model)
        {
            return await _roleService.CreateRole(model);
        }
        /// Cập nhật user
        /// <summary>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("UpdateRole")]
        //[Authorize]
        public async Task<JsonResultModel> UpdateRole(UpdateRoleModel input)
        {
            return await _roleService.UpdateRole(input);
        }
        /// <summary>
        /// Xoá user
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("DeleteRole/{ID}")]
        //[Authorize]
        public async Task<JsonResultModel> DeleteRole(int ID)
        {
            return await _roleService.DeleteRole(ID);
        }
        [HttpGet("GetListAllRole")]
        public async Task<JsonResultModel> GetListAllRole()
        {
            return await _roleService.GetListAllRole();
        }
    }
}
