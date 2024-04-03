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

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, string bucketName)
        {
            if (file != null && file.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString();

                Dictionary<string, string> metadata = null; // Add metadata if needed

                var arg = new PutObjectArgs().WithBucket(bucketName)
                    .WithFileName(uniqueFileName)
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
