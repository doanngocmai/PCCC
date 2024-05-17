using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using PCCC.API.MinIOs;
using PCCC.Common.DTOs.News;
using PCCC.Common.Utils;
using PCCC.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Reflection.PortableExecutable;
using System.Security.AccessControl;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/web/[controller]")]
    [ApiExplorerSettings(GroupName = "WebAdmin")]
    [ApiController]
    [SwaggerTag("New")]
    public class NewController : ControllerBase
    {
        public readonly INewService _newService;
        public NewController(INewService newService)
        {
            _newService = newService;
        }
        [HttpGet("GetListNew")]
        //[Authorize]
        public async Task<JsonResultModel> GetListNew([FromQuery] NewSearchPageResults param)
        {
            return await _newService.GetListNew(param);
        }
        //[Authorize]
        [HttpPost("CreateNew")]
        public async Task<JsonResultModel> CreateNew([FromForm] CreateNewModel model)
        {
            var aws = new MinioService();
            //var imageUrl = await aws.UploadFile(model.ImageFile, "news");// dùng cho IFormFile
            var imageUrl = await aws.UploadFile(model.Image, "news");// dùng cho base64
            model.Image = imageUrl;
            return await _newService.CreateNew(model);
        } 

        [HttpPost("UpdateNew")] 
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