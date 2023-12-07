using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.WebAPI.Filters;
using Karami.UseCase.CategoryUseCase.Commands.Create;
using Karami.UseCase.CategoryUseCase.Commands.Delete;
using Karami.UseCase.CategoryUseCase.Commands.Update;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.CategoryUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.CategoryUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.CategoryUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Karami.Common.ClassConsts.Route;

namespace Karami.WebAPI.EntryPoints.HTTPs.AdminPanel.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
public class CategoryController : BaseCategoryController
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
    [Route(Route.ReadOneCategoryUrl)]
    public async Task<IActionResult> ReadOne([FromQuery] ReadOneQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

        return new JsonResult(result);
    }

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

        return new JsonResult(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [Route(Route.CreateCategoryUrl)]
    public async Task<IActionResult> Create([FromBody] CreateCommand command, CancellationToken cancellationToken)
    { 
        var result = await _mediator.DispatchAsync<CreateResponse>(command, cancellationToken);
    
        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.UpdateCategoryUrl)]
    public async Task<IActionResult> Update([FromBody] UpdateCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<UpdateResponse>(command, cancellationToken);
    
        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.DeleteCategoryUrl)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);
    
        return new JsonResult(result);
    }
}