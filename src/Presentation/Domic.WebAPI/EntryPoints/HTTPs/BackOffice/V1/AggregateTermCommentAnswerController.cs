using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.Queries.ReadOne;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;


namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/AggregateTermCommentAnswer")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseAggregateTermUrl)]
public class AggregateTermCommentAnswerController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadOneAggregateCommentAnswerUrl)]
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
    [Route(Route.ReadAllPaginatedAggregateCommentAnswersUrl)]
  //[PermissionPolicy(Type = "AggregateTermComment.ReadAllPaginated")]
    public async Task<IActionResult> ReadAllPaginated([FromRoute] string CommentId, 
        [FromQuery] ReadAllPaginatedQuery query, CancellationToken cancellationToken
    )
    {
        query.Active = false; //all
        query.CommentId = CommentId;
        
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}