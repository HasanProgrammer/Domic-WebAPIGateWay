using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CategoryUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.CategoryUseCase.Queries.ReadAllPaginated;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Home/Category")]
[Route(Route.BaseHomeUrl + Route.BaseCategoryUrl)]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public CategoryController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadAllPaginatedCategoryUrl)]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}