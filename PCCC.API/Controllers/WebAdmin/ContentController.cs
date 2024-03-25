using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCCC.Common.DTOs.Authentications;
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
    [SwaggerTag("Content")]
    public class ContentController : ControllerBase
    {
        public readonly IContentService _contentService;
        public ContentController(IContentService contentService)
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
        public async Task<JsonResultModel> CreateContents(CreateContentModel model)
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
