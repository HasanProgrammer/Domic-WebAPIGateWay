using Karami.Core.Common.ClassConsts;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.WebAPI.Filters;
using Karami.UseCase.PermissionUseCase.Commands.Create;
using Karami.UseCase.PermissionUseCase.Commands.Delete;
using Karami.UseCase.PermissionUseCase.Commands.Update;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.PermissionUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.PermissionUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.PermissionUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Route = Karami.Common.ClassConsts.Route;

namespace Karami.WebAPI.EntryPoints.HTTPs.AdminPanel.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
public class PermissionController : BasePermissionController
{
    private readonly IMediator _mediator;

    public PermissionController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadOnePermissionUrl)]
    [PermissionPolicy(Type = Permission.PermissionReadOne)]
    public async Task<IActionResult> ReadOne([FromQuery] ReadOneQuery query, CancellationToken cancellationToken)
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
    [Route(Route.ReadAllPaginatedPermissionUrl)]
    [PermissionPolicy(Type = Permission.PermissionReadAllPaginated)]
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
    [Route(Route.CreatePermissionUrl)]
    [PermissionPolicy(Type = Permission.PermissionCreate)]
    public async Task<IActionResult> Create([FromBody] CreateCommand command,
        CancellationToken cancellationToken
    )
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
    [Route(Route.UpdatePermissionUrl)]
    [PermissionPolicy(Type = Permission.PermissionUpdate)]
    public async Task<IActionResult> Update([FromBody] UpdateCommand command,
        CancellationToken cancellationToken
    )
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
    [Route(Route.DeletePermissionUrl)]
    [PermissionPolicy(Type = Permission.PermissionDelete)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
}