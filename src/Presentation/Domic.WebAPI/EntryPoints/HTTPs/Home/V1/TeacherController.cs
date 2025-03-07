using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateTermUseCase.Queries.ReadAllPaginated;
using Domic.WebAPI.DTOs;
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
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route($"{Route.BaseAggregateTermUrl}/{Route.ReadAllPaginatedAggregateTermUrl}")]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] LandingTermDto dto, 
        CancellationToken cancellationToken
    )
    {
        var query = new ReadAllPaginatedQuery {
            PageNumber = dto.PageNumber,
            CountPerPage = dto.CountPerPage,
            UserId = dto.UserId,
            SearchText = dto.SearchText,
            Active = true
        };
        
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return new JsonResult(result);
    }
}