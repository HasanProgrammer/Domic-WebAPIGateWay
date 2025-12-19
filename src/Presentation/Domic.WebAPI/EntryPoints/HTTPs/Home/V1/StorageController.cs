#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

using Domic.Core.Common.ClassExtensions;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route   = Domic.Common.ClassConsts.Route;
using ILogger = Domic.Core.UseCase.Contracts.Interfaces.ILogger;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[Authorize]
[ApiExplorerSettings(GroupName = "Home/Storage")]
[Route($"{Route.BaseHomeUrl}{Route.BaseStorageUrl}")]
[ApiVersion("1.0")]
public class StorageController(IConfiguration configuration, IWebHostEnvironment hostEnvironment,
    ILogger logger
) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost(Route.UploadStorageUrl)]
    public async Task<IActionResult> Upload([FromQuery] string fileName, CancellationToken cancellationToken)
    {
        //var uploadResult = await file.UploadAsync(hostEnvironment, cancellationToken: cancellationToken);
        
        var extension = Path.GetExtension(fileName);
        var newFileName = Guid.NewGuid().ToString().Replace("-", "") + extension;

        string filePath = default;

        if ( new[] { ".png", ".jpg", ".jpeg" }.Contains(extension.ToLower()) )
            filePath = Path.Combine(hostEnvironment.ContentRootPath ?? "", "Storages", "Images", newFileName);
        else if( new[] { ".mp4", ".avi" }.Contains(extension.ToLower()) )
            filePath = Path.Combine(hostEnvironment.ContentRootPath ?? "", "Storages", "Videos", newFileName);

        await using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024*1024, true);
        
        await Request.Body?.CopyToAsync(stream, cancellationToken);

        logger.RecordAsync(Guid.NewGuid().ToString(), "WebAPIGateWay", filePath, cancellationToken);
        
        var uploadPath = hostEnvironment.IsDevelopment()
            ? filePath.Replace("Storages", "")
            : filePath.Split("Storages")[1];

        return HttpContext.OkResponse(
            new {
                Code = configuration.GetSuccessStatusCode(),
                Message = configuration.GetSuccessCreateMessage(),
                Body = new { UploadPath = $"{Request.Scheme}://{Request.Host}/Files{uploadPath.Replace("\\", "/")}" }
            }
        );
    }
}