using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ApartmentUserController : ControllerBase
    {
        public readonly IContentService _contentService;
        public ApartmentUserController (IContentService contentService)
        {
            _contentService = contentService;
        }
        [HttpGet("GetListContent")]
        //[Authorize]
        public async Task<JsonResultModel> GetListContent([FromQuery] ContentSearchPageResults param)
        {
            return await _contentService.GetListContent(param);
        }
        //[Authorize]
        [HttpPost("CreateContent")]
        public async Task<JsonResultModel> CreateContent(CreateContentModel model)
        {
            return await _contentService.CreateContent(model);
        }
        [HttpPost("UpdateContent")]
        //[Authorize]
        public async Task<JsonResultModel> UpdateContent(UpdateContentModel input)
        {
            return await _contentService.UpdateContent(input);
        }
        [HttpDelete("DeleteContent/{ID}")]
        //[Authorize]
        public async Task<JsonResultModel> DeleteContent(int ID)
        {
            return await _contentService.DeleteContent(ID);
        }
    }
}
