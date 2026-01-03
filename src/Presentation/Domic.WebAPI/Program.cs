using System.Text;
using System.Threading.RateLimiting;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.WebAPI.Extensions;
using Domic.Persistence.Contexts;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;

/*-------------------------------------------------------------------*/

WebApplicationBuilder builder = WebApplication.CreateBuilder();

#region Configs

builder.WebHost.ConfigureAppConfiguration((context, builder) => builder.AddJsonFiles(context.HostingEnvironment));

builder.WebHost.ConfigureKestrel(options => {
    options.Limits.MaxRequestBodySize = null;
    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(60);
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(60);
});

#endregion

/*-------------------------------------------------------------------*/

#region ServiceContainer

builder.RegisterHelpers();
builder.RegisterELK();
builder.RegisterEntityFrameworkCoreCommand<SQLContext, string>();
builder.RegisterCommandQueryUseCases();
builder.RegisterJsonWebToken();
builder.RegisterMessageBroker();
builder.RegisterEventStreamBroker();
builder.RegisterDistributedCaching();
builder.RegisterServicesOfGrpcClientWebRequest();
builder.RegisterServices();
builder.RegisterServiceDiscovery();
builder.RegisterRefreshSecretKey();
//builder.RegisterExternalStorage();

builder.Services.AddCors(options => {
    options.AddPolicy(name: "CORS", policy  => {
        policy.WithOrigins(Environment.GetEnvironmentVariable("ClientOrigins").Split(","))
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddMvc();
builder.Services.AddApiVersioning();
builder.Services.AddHttpContextAccessor();
builder.Services.AddGrpc();
builder.Services.AddCustomSwagger();
builder.Services.Configure<FormOptions>(options => {
    options.MultipartBodyLengthLimit = long.MaxValue;
});
builder.Services.AddRateLimiter(options => {
    
    options.RejectionStatusCode = StatusCodes.Status200OK;
    
    options.OnRejected = async (context, cancellationToken) => {
        
        context.HttpContext.Response.ContentType = "application/json";
        
        var payload = new {
            Code = StatusCodes.Status429TooManyRequests,
            Message = "شما بیش از حد مجاز و در محدوده زمانی مشخص درخواست ارسال کرده اید! ( حد مجاز : 10 درخواست در دقیقه )",
            Body = new {}
        };

        await context.HttpContext.Response.WriteAsync(
            payload.Serialize(), Encoding.UTF8, cancellationToken
        );
        
    };
    
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext => 
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown-ip",
            factory: _ => new FixedWindowRateLimiterOptions {
                PermitLimit = 10,
                Window = TimeSpan.FromMinutes(1),
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                QueueLimit = 0 
            }
        )
    );
    
});

#endregion

/*-------------------------------------------------------------------*/

WebApplication application = builder.Build();

/*-------------------------------------------------------------------*/

#region Middleware

/*application.Use(async (context, next) => {
    var maxRequestBodySizeFeature = context.Features.Get<IHttpMaxRequestBodySizeFeature>();
    if (maxRequestBodySizeFeature is not null)
        maxRequestBodySizeFeature.MaxRequestBodySize = int.MaxValue;
    await next();
});*/

application.UseStaticFiles(new StaticFileOptions {
    FileProvider = new PhysicalFileProvider( Path.Combine(Directory.GetCurrentDirectory(), "Storages") ),
    RequestPath  = "/Files"
});

application.UsePreFlightCors();

application.UseCoreExceptionHandler(application.Configuration);

if (application.Environment.IsProduction())
{
    application.UseHsts();
    application.UseHttpsRedirection();
}

application.UseCustomSwagger(application.Environment);

application.UseRouting();

application.UseCors("CORS");

application.UseRateLimiter();

application.UseAuthentication();

application.UseAuthorization();

application.UseObservibility();

application.UseEndpoints(endpoints => {
    
    endpoints.HealthCheck(application.Services);

    endpoints.MapControllers();

});

#endregion

/*-------------------------------------------------------------------*/

application.Run();

/*-------------------------------------------------------------------*/

//For Integration Test

public partial class Program;