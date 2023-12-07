using Karami.Core.Common.ClassConsts;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.WebAPI.Filters;
using Karami.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Karami.Common.ClassConsts.Route;

namespace Karami.WebAPI.EntryPoints.HTTPs.AdminPanel.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
public class AggregateArticleController : BaseAggregateArticleController
{
    private readonly IMediator _mediator;

    public AggregateArticleController(IMediator mediator) => _mediator = mediator;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadAllPaginatedAggregateArticleUrl)]
    [PermissionPolicy(Type = Permission.AggregateArticleReadAllPaginated)]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return new JsonResult(result);
    }
}