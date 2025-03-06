using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadAllPaginated;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[ApiExplorerSettings(GroupName = "Home/Teacher")]
[Route($"{Route.BaseHomeUrl}{Route.BaseAggregateTermUrl}")]
[ApiVersion("1.0")]
public class TeacherController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route($"{Route.BaseAggregateTermUrl}/{Route.ReadAllPaginatedAggregateTermUrl}")]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return new JsonResult(result);
    }
}