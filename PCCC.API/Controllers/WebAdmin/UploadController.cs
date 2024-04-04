using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using System.Security.AccessControl;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly MinioClient _minioClient;

        public UploadController(MinioClient minioClient)
        {
            _minioClient = minioClient;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUrl(string bucketID)
        {
            return Ok(await _minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
                    .WithBucket(bucketID))
                .ConfigureAwait(false));
        }
        //private string APP_BUCKET = "image-pccc";
        //private async bool CheckAndCreateBucket(string bucketName)
        //{
        //    var beArgs = new BucketExistsArgs()
        //      .WithBucket(bucketName);
        //    bool found = await _minioClient.BucketExistsAsync(beArgs).ConfigureAwait(false);
        //    if (!found)
        //    {
        //        var mbArgs = new MakeBucketArgs()
        //            .WithBucket(bucketName);
        //        await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
        //    }
        //    return found;
        //}
        //public async Task<string> UploadFileToMinio( int objectId, ObjectType type,Stream fileStream,string fileName, string contentType)
        //{
        //    await CheckAndCreateBucket(APP_BUCKET) ;
        //    var folder = type switch
        //    {
        //        ObjectType.Asset => "file-asset",
        //        ObjectType.Request => "file-request",
        //        ObjectType.HistoryRequest => "file-request-history",
        //        _ => "file-lungtung"
        //    };
        //    folder += "/" + fileName;
        //    var args = new PutObjectArgs()
        //        .WithBucket(APP_BUCKET)
        //        .WithObject(folder)
        //        .WithStreamData(fileStream)
        //        .WithObjectSize(fileStream.Length)
        //        .WithContentType(contentType);

        //    _ = await _minioClient.PutObjectAsync(args);
        //    return folder;
        //}
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, string bucketName)
        {
            if (file != null && file.Length > 0)
            {
                var beArgs = new BucketExistsArgs()
                  .WithBucket(bucketName);
                bool found = await _minioClient.BucketExistsAsync(beArgs).ConfigureAwait(false);
                if (!found)
                {
                    var mbArgs = new MakeBucketArgs()
                        .WithBucket(bucketName);
                    await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
                }
                string uniqueFileName = Guid.NewGuid().ToString();
                var arg = new PutObjectArgs().WithBucket(bucketName)
                    .WithFileName(file.FileName)
                    .WithObject(uniqueFileName)
                    .WithContentType(file.ContentType);
                await _minioClient.PutObjectAsync(arg);
                // Return appropriate response indicating success or failure
                return Ok("File uploaded successfully");
            }
            else
            {
                return BadRequest("No file was uploaded");
            }
        }
    }
}
