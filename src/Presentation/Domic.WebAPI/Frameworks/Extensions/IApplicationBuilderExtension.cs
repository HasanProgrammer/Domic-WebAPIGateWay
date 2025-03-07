using System.Net;
using Domic.Infrastructure.Implementations.UseCase.Services;
using Domic.UseCase.Commons.Contracts.Interfaces;
using Domic.WebAPI.Frameworks.Middlewares;
using Minio;

namespace Domic.WebAPI.Frameworks.Extensions;

public static class IApplicationBuilderExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void RegisterExternalStorage(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IExternalStorageManager, ExternalStorageManager>();

        builder.Services.AddMinio(configureClient => 
            configureClient.WithEndpoint(
                               Environment.GetEnvironmentVariable("Minio-EndPoint")
                           )
                           .WithCredentials(
                               Environment.GetEnvironmentVariable("Minio-AccessKey"), 
                               Environment.GetEnvironmentVariable("Minio-SecretKey")
                           )
                           .WithSSL(false)
            
        );
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Builder"></param>
    public static void UsePreFlightCors(this IApplicationBuilder Builder) 
        => Builder.UseMiddleware<PreFlightCorsHandler>();
}