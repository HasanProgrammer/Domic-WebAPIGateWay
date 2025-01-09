using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route                    = Domic.Common.ClassConsts.Route;
using ReadAllPaginatedResponse = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/AggregateTicket")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseAggregateTicketUrl)]
public class AggregateTicketController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route($"{Route.BaseAggregateTicketUrl}/{Route.ReadOneAggregateTicketUrl}")]
    [PermissionPolicy(Type = "AggregateTicket.ReadOne")]
    public async Task<IActionResult> ReadOne([FromRoute] ReadOneQuery query, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadAllPaginatedAggregateTicketUrl)]
    [PermissionPolicy(Type = "AggregateTicket.ReadAllTransactionRequestPaginated")]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return new JsonResult(result);
    }
}