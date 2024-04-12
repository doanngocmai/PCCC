using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCCC.Common.DTOs.Roles;
using PCCC.Common.DTOs.UpgradeAccs;
using PCCC.Common.Utils;
using PCCC.Service.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/web/[controller]")]
    [ApiExplorerSettings(GroupName = "WebAdmin")]
    [ApiController]
    [SwaggerTag("UpgradeAccount")]
    public class UpgradeAccountController : ControllerBase
    {
        public readonly IUpgradeAccService _upgradeAccService;
        public UpgradeAccountController(IUpgradeAccService upgradeAccService)
        {
            _upgradeAccService = upgradeAccService;
        }
        [HttpGet("GetListUpgradeAccount")]
        //[Authorize]
        public async Task<JsonResultModel> GetListUpgradeAccount([FromQuery] UpgradeAccSearchPageResult param)
        {
            return await _upgradeAccService.GetListUpgradeAccount(param);
        }
        [HttpPost("CreateUpgradeAcc")]
        public async Task<JsonResultModel> CreateUpgradeAcc(CreateUpgradeAccModel model)
        {
            return await _upgradeAccService.CreateUpgradeAcc(model);
        }
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("UpdateUpgradeAcc")]
        //[Authorize]
        public async Task<JsonResultModel> UpdateUpgradeAcc(UpdateUpgradeAccModel input)
        {
            return await _upgradeAccService.UpdateUpgradeAcc(input);
        }
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUpgradeAcc/{ID}")]
        //[Authorize]
        public async Task<JsonResultModel> DeleteUpgradeAcc(int ID)
        {
            return await _upgradeAccService.DeleteUpgradeAcc(ID);
        }
    }
}
