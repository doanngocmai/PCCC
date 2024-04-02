using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using PCCC.Common.DTOs.News;
using PCCC.Common.Utils;
using PCCC.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/web/[controller]")]
    [ApiExplorerSettings(GroupName = "WebAdmin")]
    [ApiController]
    [SwaggerTag("New")]
    public class NewController : ControllerBase
    {
        public readonly INewService _newService;
        private readonly IMinioClient _minio;
        public NewController(INewService newService, IMinioClient minio)
        {
            _newService = newService;
            _minio = minio;
        }
        [HttpGet("GetListNew")]
        //[Authorize]
        public async Task<JsonResultModel> GetListNew([FromQuery] NewSearchPageResults param)
        {
            return await _newService.GetListNew(param);
        }
        //[Authorize]
        [HttpPost("CreateNew")]
        public async Task<JsonResultModel> CreateNew(CreateNewModel model)
        {
            return await _newService.CreateNew(model);
        }
        [HttpPost("UpdateNew")]
        //[Authorize]
        public async Task<JsonResultModel> UpdateNew(UpdateNewModel input)
        {
            return await _newService.UpdateNew(input);
        }
        [HttpDelete("DeleteNew/{ID}")]
        //[Authorize]
        public async Task<JsonResultModel> DeleteNew(int ID)
        {
            return await _newService.DeleteNew(ID);
        }
    }
}