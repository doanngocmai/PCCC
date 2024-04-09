using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using PCCC.API.MinIOs;
using System.Security.AccessControl;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IMinioClient _minioClient;
        private readonly IConfiguration _configuration;

        public UploadController(IMinioClient minioClient, IConfiguration configuration)
        {
            _minioClient = minioClient.WithSSL(false);
            _configuration = configuration;
        }
        //Các headerType:
        //Hình ảnh JPEG: "image/jpeg"
        //Hình ảnh PNG: "image/png"
        //Tệp PDF: "application/pdf"
        //Văn bản thuần(plain text) : "text/plain"
        //Tệp CSV: "text/csv"
        //Tệp JSON: "application/json"
        //Tệp XML: "application/xml"
        [HttpGet("GetUrl")]
        public Task<string> GetUrl(string fileName, string headerType)
        {
            string APP_BUCKET = _configuration["minio:APP_BUCKET"];
            var header = new Dictionary<string, string> { { "response-content-type", headerType } };
            var args = new PresignedGetObjectArgs()
                .WithBucket(APP_BUCKET)
                .WithObject(fileName)
                .WithHeaders(header)
                .WithExpiry(60 * 60 * 24);

            return _minioClient.PresignedGetObjectAsync(args);
        }
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUrl(string bucketID)
        {
            return Ok(await _minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
                    .WithBucket(bucketID))
                .ConfigureAwait(false));
        }
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage()
        {
            var objectName = "news";
            var filePath = "D:\\Figma\\image\\logo_nobg.png";
            var contentType = "application/png";
            string bucketName = _configuration["minio:APP_BUCKET"];
            string url = _configuration["minio:MINIO_END_POINT"];
            // Make a bucket on the server, if not already present.
            var beArgs = new BucketExistsArgs()
                .WithBucket(bucketName);
            bool found = await _minioClient.BucketExistsAsync(beArgs).ConfigureAwait(false);
            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket(bucketName);
                await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            }
            // Upload a file to bucket.
            var putObjectArgs = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithFileName(filePath)
                .WithContentType(contentType);
            await _minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
            return Ok("https:" + bucketName + "." + url + "/" + objectName + "/" + filePath);
        }
        private async Task<bool> CheckAndCreateBucket(string bucketName)
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
            return found;
        }
        [HttpPost("UploadFileToMinio")]
        public async Task<IActionResult> UploadFileToMinio(IFormFile file)
        {
            try
            {
                string APP_BUCKET = _configuration["minio:APP_BUCKET"];
                string filePath = "news";
                await CheckAndCreateBucket(APP_BUCKET);
                var folder = filePath + "/" + file.FileName;
                var ms = new MemoryStream();
                file.CopyTo(ms);
                ms.Position = 0;
                var args = new PutObjectArgs()
                    .WithBucket(APP_BUCKET)
                    .WithObject(file.FileName)
                    .WithStreamData(ms)
                    .WithObjectSize(file.Length)
                    .WithContentType(file.ContentType);
                var a =await _minioClient.PutObjectAsync(args);
                return Ok("http://" + folder);

            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        [HttpPost("Test")]
        public async Task<string> Test(IFormFile file)
        {
            var aws = new MinioService();
            var image = await aws.UploadFile(file, "news");
            return image;
        }
    }
}
