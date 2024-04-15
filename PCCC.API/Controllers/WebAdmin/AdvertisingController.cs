using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCCC.Common.DTOs.Ads;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.Utils;
using PCCC.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/web/[controller]")]
    [ApiExplorerSettings(GroupName = "WebAdmin")]
    [ApiController]
    [SwaggerTag("Advertising")]
    public class AdvertisingController : ControllerBase
    {
        public readonly IAdvertisingService _advertisingService;
        public AdvertisingController(IAdvertisingService advertisingService)
        {
            _advertisingService = advertisingService;
        }
        [HttpGet("GetListContent")]
        //[Authorize]
        public async Task<JsonResultModel> GetListContent([FromQuery] AdsSearchPageResults param)
        {
            return await _advertisingService.GetListAds(param);
        }
        //[Authorize]
        [HttpPost("CreateAds")]
        public async Task<JsonResultModel> CreateAds(CreateAdsModel model)
        {
            return await _advertisingService.CreateAds(model);
        }
        [HttpPost("UpdateAds")]
        //[Authorize]
        public async Task<JsonResultModel> CreateAds(UpdateAdsModel input)
        {
            return await _advertisingService.UpdateAds(input);
        }
        [HttpDelete("DeleteAds/{ID}")]
        //[Authorize]
        public async Task<JsonResultModel> DeleteAds(int ID)
        {
            return await _advertisingService.DeleteAds(ID);
        }
    }
}
