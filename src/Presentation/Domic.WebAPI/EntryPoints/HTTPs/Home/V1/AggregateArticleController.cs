using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateArticleUseCase.Queries.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Mvc;

using ReadAllPaginatedResponse = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadOneResponse          = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using Route                    = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Home/Article")]
[Route($"{Route.BaseHomeUrl}{Route.BaseAggregateArticleUrl}")]
public class AggregateArticleController(IMediator mediator, [FromKeyedServices("Http1")] IIdentityUser identityUser) 
    : ControllerBase
{
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
        var result = await mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

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
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadAllPaginatedAggregateArticleCurrentUserUrl)]
    public async Task<IActionResult> ReadAllPaginatedCurrentUser([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        query.UserId = identityUser.GetIdentity();

        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}