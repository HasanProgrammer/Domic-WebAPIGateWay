using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.PermissionUseCase.Commands.Create;
using Domic.UseCase.PermissionUseCase.Commands.Delete;
using Domic.UseCase.PermissionUseCase.Commands.Update;
using Domic.UseCase.PermissionUseCase.Queries.ReadAllBasedOnRolesPaginated;
using Domic.UseCase.PermissionUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.PermissionUseCase.Queries.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using CreateResponse                       = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Create.CreateResponse;
using UpdateResponse                       = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Update.UpdateResponse;
using DeleteResponse                       = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using ReadAllPaginatedResponse             = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllBasedOnRolesPaginatedResponse = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllBasedOnRolesPaginated.ReadAllBasedOnRolesPaginatedResponse;
using ReadOneResponse                      = Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using Route                                = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/Permission")]
[ApiVersion("1.0")]
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

        return HttpContext.OkResponse(result);
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

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadAllBasedOnRolesPaginatedPermissionUrl)]
    [PermissionPolicy(Type = Permission.PermissionReadAllPaginated)]
    public async Task<IActionResult> ReadAllBasedOnRolesPaginated([FromQuery] ReadAllBasedOnRolesPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.DispatchAsync<ReadAllBasedOnRolesPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
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

        return HttpContext.OkResponse(result);
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

        return HttpContext.OkResponse(result);
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
    public async Task<IActionResult> Delete([FromRoute] DeleteCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}