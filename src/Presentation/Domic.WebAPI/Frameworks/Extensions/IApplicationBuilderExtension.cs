using Domic.WebAPI.Frameworks.Middlewares;

namespace Domic.WebAPI.Frameworks.Extensions;

public static class IApplicationBuilderExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Builder"></param>
    public static void UsePreFlightCors(this IApplicationBuilder Builder) 
        => Builder.UseMiddleware<PreFlightCorsHandler>();
}