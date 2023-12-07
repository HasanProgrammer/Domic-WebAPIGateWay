using Karami.Core.Common.ClassConsts;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.WebAPI.Filters;
using Karami.UseCase.RoleUseCase.Commands.Create;
using Karami.UseCase.RoleUseCase.Commands.SoftDelete;
using Karami.UseCase.RoleUseCase.Commands.Update;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.RoleUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.RoleUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.RoleUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Route = Karami.Common.ClassConsts.Route;

namespace Karami.WebAPI.EntryPoints.HTTPs.AdminPanel.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
public class RoleController : BaseRoleController
{
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public RoleController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadOneRoleUrl)]
    [PermissionPolicy(Type = Permission.RoleReadOne)]
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
    [Route(Route.ReadAllPaginatedRoleUrl)]
    [PermissionPolicy(Type = Permission.RoleReadAllPaginated)]
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
    [Route(Route.CreateRoleUrl)]
    [PermissionPolicy(Type = Permission.RoleCreate)]
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
    [Route(Route.UpdateRoleUrl)]
    [PermissionPolicy(Type = Permission.RoleUpdate)]
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
    [Route(Route.DeleteRoleUrl)]
    [PermissionPolicy(Type = Permission.RoleDelete)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
}