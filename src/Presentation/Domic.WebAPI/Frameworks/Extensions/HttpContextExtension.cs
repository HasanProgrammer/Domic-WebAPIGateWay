using Domic.Core.Domain.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Domic.WebAPI.Frameworks.Extensions;

public static class HttpContextExtension
{
    /// <summary>
    /// Returns a JSON response with a 200 status code.
    /// </summary>
    /// <param name="httpContext"></param>
    /// <param name="actionResult"></param>
    /// <returns></returns>
    public static IActionResult OkResponse(this HttpContext httpContext, object actionResult)
    {
        var serializer = httpContext.RequestServices.GetRequiredService<ISerializer>();

        return new ContentResult {
            Content = serializer.Serialize(actionResult),
            ContentType = "application/json",
            StatusCode = 200
        };
    }
}