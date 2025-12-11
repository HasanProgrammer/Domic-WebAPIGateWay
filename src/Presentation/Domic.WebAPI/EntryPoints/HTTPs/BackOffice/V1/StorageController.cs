using Domic.Common.ClassExtensions;
using Domic.Core.Common.ClassExtensions;
using Domic.Core.WebAPI.Filters;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/Storage")]
[Route($"{Route.BaseBackOfficeUrl}{Route.BaseStorageUrl}")]
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
    [DisableRequestSizeLimit]
    public async Task<IActionResult> Upload([FromForm] IFormFile file, CancellationToken cancellationToken)
    {
        var uploadResult = await file.UploadToLocalStorageAsync(hostEnvironment, cancellationToken: cancellationToken);

        return HttpContext.OkResponse(
            new {
                Code = configuration.GetSuccessStatusCode(),
                Message = configuration.GetSuccessCreateMessage(),
                Body = new { UploadPath = $"{Request.Scheme}://{Request.Host}/Files{uploadResult.path.Replace("Storages", "").Replace("\\", "/")}" }
            }
        );
    }
}