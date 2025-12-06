using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.AggregateArticleUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateArticleUseCase.Queries.ReadOne;
using Domic.WebAPI.DTOs;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ReadAllPaginatedResponse = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadOneResponse          = Domic.UseCase.AggregateArticleUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using Route                    = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Home/Author")]
[Route($"{Route.BaseHomeUrl}{Route.BaseAggregateArticleUrl}")]
public class AuthorController(IMediator mediator, [FromKeyedServices("Http1")] IIdentityUser identityUser) 
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
    public async Task<IActionResult> ReadAllPaginated([FromQuery] LandingArticleDto dto,
        CancellationToken cancellationToken
    )
    {
        var query = new ReadAllPaginatedQuery {
            UserId = dto.UserId,
            SearchText = dto.SearchText,
            PageNumber = dto.PageNumber,
            CountPerPage = dto.CountPerPage,
            IsActive = true
        };
        
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [PermissionPolicy(Type = "Article.ReadAllPaginatedCurrentUser")]
    [HttpGet(Route.ReadAllPaginatedAggregateArticleCurrentUserUrl)]
    public async Task<IActionResult> ReadAllPaginatedCurrentUser([FromQuery] LandingArticleCurrentUserDto dto,
        CancellationToken cancellationToken
    )
    {
        var query = new ReadAllPaginatedQuery {
            UserId = identityUser.GetIdentity(),
            SearchText = dto.SearchText,
            PageNumber = dto.PageNumber,
            CountPerPage = dto.CountPerPage,
            IsActive = dto.IsActive
        };

        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}