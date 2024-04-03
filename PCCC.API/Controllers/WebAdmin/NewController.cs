using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
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
            // Kiểm tra và upload ảnh lên Minio nếu có
            //if (model.Image != null)
            //{
            //    // Tên bucket để lưu trữ ảnh
            //    string bucketName = "news";
            //    var beArgs = new BucketExistsArgs()
            //       .WithBucket(bucketName);

            //    bool found = await _minio.BucketExistsAsync(beArgs).ConfigureAwait(false);
            //    if (!found)
            //    {
            //        var mbArgs = new MakeBucketArgs()
            //            .WithBucket(bucketName);
            //        await _minio.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            //    }
            //    // Upload a file to bucket.
            //    var putObjectArgs = new PutObjectArgs()
            //    .WithBucket(bucketName)
            //        .WithFileName(model.Image);
            //    await _minio.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
            //    Console.WriteLine("Successfully uploaded ");
            //    // Tạo một tên duy nhất cho ảnh
            //    string objectName = Guid.NewGuid().ToString();
            //    // Lưu lại đường dẫn ảnh trong model hoặc làm gì đó khác với đường dẫn ảnh
            //    string imageUrl = $"https://{bucketName}/{objectName}";
            //    model.Image = imageUrl; // Gán đường dẫn ảnh vào thuộc tính Image của model
            //}

            // Gọi service để xử lý logic và trả về kết quả
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