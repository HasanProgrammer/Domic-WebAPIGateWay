using System.Diagnostics;
using Domic.Infrastructure.Implementations.UseCase.Services;
using Domic.UseCase.Commons.Contracts.Interfaces;
using Domic.WebAPI.Frameworks.Middlewares;
using Prometheus;

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

        /*builder.Services.AddMinio(configureClient => 
            configureClient.WithEndpoint(
                               Environment.GetEnvironmentVariable("Minio-EndPoint")
                           )
                           .WithCredentials(
                               Environment.GetEnvironmentVariable("Minio-AccessKey"), 
                               Environment.GetEnvironmentVariable("Minio-SecretKey")
                           )
                           .WithSSL(false)
            
        );*/
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void UseObservibility(this IApplicationBuilder builder)
    {
        var requestsCounter = Metrics.CreateCounter("http_requests_total", "Total HTTP requests");
        var memoryGauge = Metrics.CreateGauge("app_memory_bytes", "Current memory usage in bytes");
        var cpuGauge = Metrics.CreateGauge("app_cpu_percent", "Current CPU usage percentage");
        var gcGauge = Metrics.CreateGauge("gc_total_memory_bytes", "GC total memory");

        PerformanceCounter cpuCounter = null;
        if (OperatingSystem.IsWindows())
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        builder.UseMetricServer();
        builder.UseHttpMetrics();

        builder.Use(async (context, next) => {
            
            requestsCounter.Inc();

            memoryGauge.Set(GC.GetTotalMemory(forceFullCollection: false));

            if (cpuCounter != null)
            {
                cpuGauge.Set(cpuCounter.NextValue());
            }
            else
            {
                var process = Process.GetCurrentProcess();
                cpuGauge.Set(process.TotalProcessorTime.TotalMilliseconds / Environment.ProcessorCount);
            }

            gcGauge.Set(GC.GetTotalMemory(forceFullCollection: false));

            await next();
            
        });
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Builder"></param>
    public static void UsePreFlightCors(this IApplicationBuilder Builder) 
        => Builder.UseMiddleware<PreFlightCorsHandler>();
}