using Minio.DataModel.Args;
using Minio;
using PCCC.Repository.Interfaces;

namespace PCCC.API.MinIOs
{
    public class MinioService
    {
        private readonly IMinioClient _minioClient;
        private readonly IConfiguration _configuration;

        public MinioService(IMinioClient minioClient, IConfiguration configuration)
        {
            _minioClient = minioClient.WithSSL(false);
            _configuration = configuration;
        }

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
        public async Task<string> UploadFileToMinio(IFormFile file, Stream fileStream, string folderName)
        {
            string APP_BUCKET = _configuration["minio:APP_BUCKET"];
            await CheckAndCreateBucket(APP_BUCKET);
            //var folder = type switch
            //{
            //    ObjectType.Asset => "file-asset",
            //    ObjectType.Request => "file-request",
            //    ObjectType.HistoryRequest => "file-request-history",
            //    _ => "file-lungt ung"
            //};
            var folder = folderName +  "/" + file.FileName;
            var args = new PutObjectArgs()
                .WithBucket(APP_BUCKET)
                .WithObject(folder)
                .WithStreamData(fileStream)
                .WithObjectSize(fileStream.Length)
                .WithContentType(file.ContentType);

            _ = await _minioClient.PutObjectAsync(args);
            return folder;
        }
    }
}
