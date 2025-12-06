using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.AggregateTermCommentUseCase.Queries.ReadOne;
using Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateTermCommentUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;


namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/AggregateTermComment")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseAggregateTermUrl)]
public class AggregateTermCommentController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadOneAggregateCommentUrl)]
    //[PermissionPolicy(Type = "AggregateTermComment.ReadAllTransactionRequestPaginated")]
    public async Task<IActionResult> ReadOne([FromQuery] ReadOneQuery query,
        CancellationToken cancellationToken
    )
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
    [Route(Route.ReadAllPaginatedAggregateCommentUrl)]
  //[PermissionPolicy(Type = "AggregateTermComment.ReadAllPaginated")]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        query.Active = false; //all
        
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}