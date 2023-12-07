using Karami.Core.Common.ClassConsts;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.WebAPI.Extensions;
using Karami.Persistence.Contexts;
using Karami.WebAPI.Frameworks.Extensions;

/*-------------------------------------------------------------------*/

WebApplicationBuilder builder = WebApplication.CreateBuilder();

#region Configs

builder.WebHost.ConfigureAppConfiguration((context, builder) => builder.AddJsonFiles(context.HostingEnvironment));

#endregion

/*-------------------------------------------------------------------*/

#region Service Container

builder.RegisterHelpers();
builder.RegisterCommandSqlServer<SQLContext>();
builder.RegisterCommandQueryUseCases();
builder.RegisterJsonWebToken();
builder.RegisterMessageBroker();
builder.RegisterCaching();
builder.RegisterServicesOfGrpcClientWebRequest();
builder.RegisterServices();
builder.RegisterServiceDiscovery();

builder.Services.AddMvc();
builder.Services.AddApiVersioning();
builder.Services.AddHttpContextAccessor();
builder.Services.AddGrpc();
builder.Services.AddCustomSwagger();

#endregion

/*-------------------------------------------------------------------*/

WebApplication application = builder.Build();

/*-------------------------------------------------------------------*/

#region Middleware

application.UsePreFlightCors(application.Configuration);

application.UseCoreExceptionHandler(Service.WebAPIGateWayService);

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

application.UseEndpoints(endpoints => {
    
    endpoints.HealthCheck(application.Services);

    endpoints.MapControllers();

});

#endregion

/*-------------------------------------------------------------------*/

application.Run();

/*-------------------------------------------------------------------*/

//For Integration Test

public partial class Program {}