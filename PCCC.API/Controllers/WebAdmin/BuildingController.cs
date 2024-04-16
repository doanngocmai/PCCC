using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCCC.Common.DTOs.Authentications;
using PCCC.Common.DTOs.Buildings;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.DTOs.Roles;
using PCCC.Common.Utils;
using PCCC.Service.Interfaces;
using PCCC.Service.Services;
using PCCCC.Service.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/web/[controller]")]
    [ApiExplorerSettings(GroupName = "WebAdmin")]
    [ApiController]
    [SwaggerTag("Building")]
    public class BuildingController : ControllerBase
    {
        public readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        [HttpGet("GetListBuilding")]
        //[Authorize]
        public async Task<JsonResultModel> GetListBuilding([FromQuery] BuildingSearchPageResults param)
        {
            return await _buildingService.GetListBuilding(param);
        }
        //[Authorize]
        [HttpPost("CreateBuilding")]
        public async Task<JsonResultModel> CreateBuilding(CreateBuildingModel model)
        {
            return await _buildingService.CreateBuilding(model);
        }
        //[Authorize]
        [HttpGet("GetBuildingById")]
        public async Task<JsonResultModel> GetBuildingById(int Id)
        {
            return await _buildingService.GetBuildingById(Id);
        }


        [HttpPost("UpdateBuilding")]
        //[Authorize]
        public async Task<JsonResultModel> UpdateBuilding(UpdateBuildingModel input)
        {
            return await _buildingService.UpdateBuilding(input);
        }
        [HttpDelete("DeleteBuilding/{ID}")]
        //[Authorize]
        public async Task<JsonResultModel> DeleteBuilding(int ID)
        {
            return await _buildingService.DeleteBuilding(ID);
        }
    }
}
