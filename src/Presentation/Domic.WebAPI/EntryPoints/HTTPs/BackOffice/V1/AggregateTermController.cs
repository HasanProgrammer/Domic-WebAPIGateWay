using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateTermUseCase.Queries.ReadAllPaginated;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route                            = Domic.Common.ClassConsts.Route;
using ReadAllBookRequest               = Domic.UseCase.AggregateBookUseCase.Queries.ReadAllPaginated.ReadAllPaginatedQuery;
using ReadAllBookResponse              = Domic.UseCase.AggregateBookUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllAggregateVideoRequest     = Domic.UseCase.AggregateVideoUseCase.Queries.ReadAllPaginated.ReadAllPaginatedQuery;
using ReadAllAggregateVideoResponse    = Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllAggregateSeasonRequest    = Domic.UseCase.AggregateSeasonUseCase.Queries.ReadAllPaginated.ReadAllPaginatedQuery;
using ReadAllAggregateSeasonResponse   = Domic.UseCase.AggregateSeasonUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllAggregateCampaignRequest  = Domic.UseCase.AggregateCampaignUseCase.Queries.ReadAllPaginated.ReadAllPaginatedQuery;
using ReadAllAggregateCampaignResponse = Domic.UseCase.AggregateCampaignUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;


namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/AggregateTerm")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseAggregateTermUrl)]
public class AggregateTermController(IMediator mediator, [FromKeyedServices("Http1")] IIdentityUser identityUser)
    : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Authorize]
    [Route(Route.ReadAllPaginatedAggregateBookUrl)]
    //[PermissionPolicy(Type = "AggregateTerm.ReadAllBooksPaginated")]
    public async Task<IActionResult> ReadAllBooksPaginated([FromQuery] ReadAllBookRequest query,
        CancellationToken cancellationToken
    )
    {
        query.UserId = identityUser.GetIdentity();
        
        var result = await mediator.DispatchAsync<ReadAllBookResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route(Route.ReadAllPaginatedAggregateTermUrl)]
  //[PermissionPolicy(Type = "AggregateTerm.ReadAllTermsPaginated")]
    public async Task<IActionResult> ReadAllTermsPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        query.Active = false;
        
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
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route(Route.ReadAllPaginatedAggregateSeasonUrl)]
    //[PermissionPolicy(Type = "AggregateTerm.ReadAllSeasonsPaginated")]
    public async Task<IActionResult> ReadAllSeasonsPaginated([FromQuery] ReadAllAggregateSeasonRequest query,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<ReadAllAggregateSeasonResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route(Route.ReadAllPaginatedAggregateVideoUrl)]
  //[PermissionPolicy(Type = "AggregateTerm.ReadAllVideosPaginated")]
    public async Task<IActionResult> ReadAllVideosPaginated([FromQuery] ReadAllAggregateVideoRequest query,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<ReadAllAggregateVideoResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route(Route.ReadAllPaginatedAggregateCampaignUrl)]
    //[PermissionPolicy(Type = "AggregateTerm.ReadAllCampaignsPaginated")]
    public async Task<IActionResult> ReadAllCampaignsPaginated([FromQuery] ReadAllAggregateCampaignRequest query,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<ReadAllAggregateCampaignResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}