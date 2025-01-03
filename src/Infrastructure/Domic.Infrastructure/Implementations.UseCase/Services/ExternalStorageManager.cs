using Domic.UseCase.Commons.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class ExternalStorageManager(IMinioClientFactory minioClientFactory) : IExternalStorageManager
{
    public async Task<string> UploadAsync(IFormFile file, CancellationToken cancellationToken)
    {
        var bucket = Environment.GetEnvironmentVariable("Minio-Bucket");
        
        using var minioClient = minioClientFactory.CreateClient();

        if (!await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucket), cancellationToken))
            await minioClient.MakeBucketAsync(
                new MakeBucketArgs{ IsBucketCreationRequest = true }.WithBucket(bucket),
                cancellationToken
            );
        
        var putObjectArgs = new PutObjectArgs().WithBucket(bucket)
                                               .WithObject($"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}")
                                               .WithStreamData(file.OpenReadStream())
                                               .WithContentType(file.ContentType)
                                               .WithObjectSize(file.Length);
        
        var response = await minioClient.PutObjectAsync(putObjectArgs, cancellationToken);
        
        if (response.ResponseStatusCode == System.Net.HttpStatusCode.OK)
        {
            var getObjectArgs = new PresignedGetObjectArgs().WithBucket(bucket)
                                                            .WithObject(response.ObjectName)
                                                            .WithExpiry(1200);
            
            var filePath = await minioClient.PresignedGetObjectAsync(getObjectArgs);
        
            return filePath;
        }

        return string.Empty;
    }
}