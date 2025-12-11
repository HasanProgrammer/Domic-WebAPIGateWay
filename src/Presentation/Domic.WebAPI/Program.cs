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

#endregion

/*-------------------------------------------------------------------*/

WebApplication application = builder.Build();


/*-------------------------------------------------------------------*/

#region Middleware

application.Use(async (context, next) => {
    var maxRequestBodySizeFeature = context.Features.Get<IHttpMaxRequestBodySizeFeature>();
    if (maxRequestBodySizeFeature != null)
        maxRequestBodySizeFeature.MaxRequestBodySize = null;
    await next();
});

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