﻿using Amazon.S3;
using Amazon;
using Amazon.S3.Transfer;
using Minio.DataModel.Args;
using Minio;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PCCC.API.MinIOs
{
    public class MinioService
    {
        private readonly string bucketName = "image-pccc";
        private readonly string awsAccessKeyId = "lsvk2QV4AMgz5yBN5LgR";
        private readonly string awsSecretAccessKey = "KMj6SPihl6mQMi5EHVs3pwgk3u2UqEJZq16j0YXP";
        private readonly string minioUrl = "http://192.168.1.15:9001/api/v1/buckets/";
        public async Task<string> UploadFile(IFormFile file, string folder)
        {
            try
            {
                var ext = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString().Replace("-", "") + ext;
                var checkFile = CheckImage(ext);
                if (checkFile)
                {
                    var config = new AmazonS3Config
                    {
                        RegionEndpoint = RegionEndpoint.USEast1, // MUST set this before setting ServiceURL and it should match the `MINIO_REGION` enviroment variable.
                        ServiceURL = "http://192.168.1.15:9000", // replace http://localhost:9000 with URL of your MinIO server
                        ForcePathStyle = true // MUST be true to work correctly with MinIO server
                    };
                    using (var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, config))
                    {
                        using (var newMemoryStream = new MemoryStream())
                        {
                            file.CopyTo(newMemoryStream);

                            var uploadRequest = new TransferUtilityUploadRequest
                            {
                                InputStream = newMemoryStream,
                                Key = folder + "/" + fileName,
                                BucketName = bucketName,
                                ContentType = file.ContentType
                            };

                            var fileTransferUtility = new TransferUtility(client);
                            await fileTransferUtility.UploadAsync(uploadRequest);
                        }
                    }

                    var objectUrl = $"{minioUrl}/{bucketName}/{folder}/{fileName}";
                    return objectUrl;
                }
                return "inValid";
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
        public bool CheckImage(string ext)
        {
            var lstExt = new List<string>()
            {
                ".bmp", ".emf", ".wmf", ".gif", ".jpeg", ".jpg", ".png", ".tiff", ".exif", ".ico"
            };
            bool isValid = true;
            if (!lstExt.Contains(ext.ToLower()))
            {
                isValid = false;
            }
            return isValid;
        }
        private async static Task createURL(MinioClient minio, string bucketName, string objectName, int expirationTime)
        {

            var reqParams = new Dictionary<string, string>(StringComparer.Ordinal)
        { { "response-content-type", "image/jpeg" } };

            PresignedGetObjectArgs args = new PresignedGetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithHeaders(reqParams)
                .WithExpiry(expirationTime);

            string url = await minio.PresignedGetObjectAsync(args);

            Console.WriteLine(url);
        }

    }
}
