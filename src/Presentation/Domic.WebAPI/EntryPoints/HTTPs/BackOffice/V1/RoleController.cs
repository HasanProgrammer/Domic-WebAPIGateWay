using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.RoleUseCase.Commands.Create;
using Domic.UseCase.RoleUseCase.Commands.SoftDelete;
using Domic.UseCase.RoleUseCase.Commands.Update;
using Domic.UseCase.RoleUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.RoleUseCase.DTOs.GRPCs.Delete;
using Domic.UseCase.RoleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.RoleUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.RoleUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.RoleUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.RoleUseCase.Queries.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/Role")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseRoleUrl)]
public class RoleController : ControllerBase
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
    public async Task<IActionResult> ReadOne([FromRoute] ReadOneQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);;
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

        return HttpContext.OkResponse(result);;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.CreateRoleUrl)]
    [PermissionPolicy(Type = Permission.RoleCreate)]
    public async Task<IActionResult> Create([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);;
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

        return HttpContext.OkResponse(result);;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route(Route.DeleteRoleUrl)]
    [PermissionPolicy(Type = Permission.RoleDelete)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);;
    }
}