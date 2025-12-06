using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateArticleUseCase.Queries.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route                    = Domic.Common.ClassConsts.Route;
using ReadOneResponse          = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadAllPaginatedResponse = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseAggregateArticleUrl)]
[ApiExplorerSettings(GroupName = "BackOffice/AggregateArticle")]
public class AggregateArticleController : ControllerBase
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
    [Route(Route.ReadOneAggregateArticleUrl)]
    public async Task<IActionResult> ReadOne([FromRoute] ReadOneQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
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

        return HttpContext.OkResponse(result);
    }
}