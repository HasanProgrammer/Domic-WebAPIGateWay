using Domic.Core.Common.ClassExtensions;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[Authorize]
[ApiExplorerSettings(GroupName = "Home/Storage")]
[Route($"{Route.BaseHomeUrl}{Route.BaseStorageUrl}")]
[ApiVersion("1.0")]
public class StorageController(IConfiguration configuration, IWebHostEnvironment hostEnvironment) 
    : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost(Route.UploadStorageUrl)]
    public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
    {
        var uploadResult = await file.UploadAsync(hostEnvironment, cancellationToken: cancellationToken);

        return HttpContext.OkResponse(
            new {
                Code = configuration.GetSuccessStatusCode(),
                Message = configuration.GetSuccessCreateMessage(),
                Body = new { UploadPath = $"{Request.Scheme}://{Request.Host}/Files{uploadResult.path.Replace("Storages", "").Replace("\\", "/")}" }
            }
        );
    }
}