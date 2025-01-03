﻿using Domic.Core.Common.ClassExtensions;
using Domic.UseCase.Commons.Contracts.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[Authorize]
[ApiExplorerSettings(GroupName = "Home/Storage")]
[Route($"{Route.BaseHomeUrl} {Route.BaseStorageUrl}")]
[ApiVersion("1.0")]
public class StorageController(IExternalStorageManager externalStorageManager, IConfiguration configuration) 
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
        var uploadPath = await externalStorageManager.UploadAsync(file, cancellationToken);

        return Ok(new {
            code = configuration.GetSuccessStatusCode(),
            message = configuration.GetSuccessCreateMessage(),
            body = new { uploadPath = uploadPath }
        });
    }
}