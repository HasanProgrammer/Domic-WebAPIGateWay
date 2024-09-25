using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.PermissionUseCase.Commands.Create;
using Domic.UseCase.PermissionUseCase.Commands.Delete;
using Domic.UseCase.PermissionUseCase.Commands.Update;
using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Delete;
using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.PermissionUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.PermissionUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
[Route(Route.BaseBackOfficeUrl + Route.BasePermissionUrl)]
public class PermissionController : ControllerBase
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
    public async Task<IActionResult> ReadOne([FromRoute] ReadOneQuery query, CancellationToken cancellationToken)
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
    [HttpPost]
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
    [HttpDelete]
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