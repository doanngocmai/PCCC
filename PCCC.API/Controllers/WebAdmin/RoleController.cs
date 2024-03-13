using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        /// <summary>
        /// Danh sách user
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="SearchKey"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet("GetListRole")]
        //[Authorize]
        public async Task<JsonResultModel> GetListRole(int page = PCCCConsts.PAGE_DEFAULT, int limit = PCCCConsts.LIMIT_DEFAULT, string SearchKey = null, int? status = null, string fromDate = null, string toDate = null)
        {
            return await _roleService.GetListRole(page, limit, SearchKey, status, fromDate, toDate);
        }
        /// <summary>
        /// Thêm tài khoản cho admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("CreateRole")]
        public async Task<JsonResultModel> CreateRole(CreateRoleModel model)
        {
            return await _roleService.CreateRole(model);
        }
    }
}
