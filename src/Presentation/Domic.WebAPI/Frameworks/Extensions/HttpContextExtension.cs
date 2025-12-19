using Domic.Core.Domain.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

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
    
    public static async Task<string> UploadFileAsync(this HttpContext httpContext,
        IWebHostEnvironment webHostEnvironment, string contentType, CancellationToken cancellationToken
    )
    {
        var fileStream = httpContext.Request.Body;

        var boundary = GetBoundary(MediaTypeHeaderValue.Parse(contentType));
        var multipartReader = new MultipartReader(boundary, fileStream);
        var section = await multipartReader.ReadNextSectionAsync(cancellationToken);

        string filePath = ""; 
        
        while (section != null)
        {
            var fileSection = section.AsFileSection();
            
            if (fileSection != null)
                filePath = await SaveFileAsync(webHostEnvironment, fileSection, cancellationToken);

            section = await multipartReader.ReadNextSectionAsync(cancellationToken);
        }

        return filePath;
    }

    private static async Task<string> SaveFileAsync(IWebHostEnvironment webHostEnvironment, 
        FileMultipartSection fileSection, CancellationToken cancellation
    )
    {
        var extension = Path.GetExtension(fileSection.FileName);
        var fileName = Guid.NewGuid().ToString().Replace("-", "") + extension;

        string filePath = default;

        if ( new[] { ".png", ".jpg", ".jpeg" }.Contains(extension.ToLower()) )
            filePath = Path.Combine(webHostEnvironment.ContentRootPath ?? "", "Storages", "Images", fileName);
        else if( new[] { ".mp4", ".avi" }.Contains(extension.ToLower()) )
            filePath = Path.Combine(webHostEnvironment.ContentRootPath ?? "", "Storages", "Videos", fileName);

        await using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024*1024, true);
        
        await fileSection.FileStream?.CopyToAsync(stream, cancellation);

        return filePath;
    }

    private static string GetBoundary(MediaTypeHeaderValue contentType)
    {
        var boundary = HeaderUtilities.RemoveQuotes(contentType.Boundary).Value;

        if (string.IsNullOrWhiteSpace(boundary))
            throw new InvalidDataException("Missing content-type boundary.");

        return boundary;
    }
}