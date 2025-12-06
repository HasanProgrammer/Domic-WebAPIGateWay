using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateTermUseCase.Queries.ReadAllPaginated;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/Teacher")]
[Route($"{Route.BaseBackOfficeUrl}{Route.BaseAggregateTermUrl}")]
[ApiVersion("1.0")]
public class TeacherController(IMediator mediator, [FromKeyedServices("Http1")] IIdentityUser identityUser) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet($"{Route.BaseAggregateTermUrl}/{Route.ReadAllPaginatedAggregateTermUrl}")]
//  [PermissionPolicy(Type = "Teacher.ReadAllPaginated")]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        query.Active = false; //all terms => active & inactive
        query.UserId = identityUser.GetIdentity();
        
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}