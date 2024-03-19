using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<JsonResultModel> GetListContent(int page = PCCCConsts.PAGE_DEFAULT, int limit = PCCCConsts.LIMIT_DEFAULT, string SearchKey = null, int? status = null, string fromDate = null, string toDate = null)
        {
            return await _contentService.GetListContent(page, limit, SearchKey, status, fromDate, toDate);
        }
        //[Authorize]
        [HttpPost("CreateContent")]
        public async Task<JsonResultModel> CreateContents(CreateContentModel model)
        {
            return await _contentService.CreateContent(model);
        }
        [HttpPost("UpdateRole")]
        //[Authorize]
        public async Task<JsonResultModel> UpdateContent(UpdateContentModel input)
        {
            return await _contentService.UpdateContent(input);
        }
        [HttpPost("DeleteRole/{ID}")]
        //[Authorize]
        public async Task<JsonResultModel> DeleteContent(int ID)
        {
            return await _contentService.DeleteContent(ID);
        }
    }
}
