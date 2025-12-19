#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

using Domic.Core.Common.ClassExtensions;
using Domic.Core.WebAPI.Filters;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route   = Domic.Common.ClassConsts.Route;
using ILogger = Domic.Core.UseCase.Contracts.Interfaces.ILogger;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/Storage")]
[Route($"{Route.BaseBackOfficeUrl}{Route.BaseStorageUrl}")]
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
    public async Task<IActionResult> Upload(CancellationToken cancellationToken)
    {
        //var uploadResult = await file.UploadAsync(hostEnvironment, cancellationToken: cancellationToken);
        var uploadResult =
            await HttpContext.UploadFileAsync(hostEnvironment, Request.ContentType, cancellationToken: cancellationToken);

        logger.RecordAsync(Guid.NewGuid().ToString(), "WebAPIGateWay", uploadResult, cancellationToken);
        
        var uploadPath = hostEnvironment.IsDevelopment()
            ? uploadResult.Replace("Storages", "")
            : uploadResult.Split("Storages")[1];
        
        return HttpContext.OkResponse(
            new {
                Code = configuration.GetSuccessStatusCode(),
                Message = configuration.GetSuccessCreateMessage(),
                Body = new { UploadPath = $"{Request.Scheme}://{Request.Host}/Files{uploadPath.Replace("\\", "/")}" }
            }
        );
    }
}