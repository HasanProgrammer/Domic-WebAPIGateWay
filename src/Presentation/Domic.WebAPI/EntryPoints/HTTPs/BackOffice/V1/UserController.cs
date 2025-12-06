using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.UserUseCase.Commands.Active;
using Domic.UseCase.UserUseCase.Commands.Create;
using Domic.UseCase.UserUseCase.Commands.InActive;
using Domic.UseCase.UserUseCase.Commands.Update;
using Domic.UseCase.UserUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.UserUseCase.Queries.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Route                    = Domic.Common.ClassConsts.Route;
using ReadOneResponse          = Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadAllPaginatedResponse = Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using CreateResponse           = Domic.UseCase.UserUseCase.DTOs.GRPCs.Create.CreateResponse;
using UpdateResponse           = Domic.UseCase.UserUseCase.DTOs.GRPCs.Update.UpdateResponse;
using ActiveResponse           = Domic.UseCase.UserUseCase.DTOs.GRPCs.Active.ActiveResponse;
using InActiveResponse         = Domic.UseCase.UserUseCase.DTOs.GRPCs.InActive.InActiveResponse;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[BlackListPolicy]
[Authorize(Roles = "SuperAdmin,Admin")]
[ApiExplorerSettings(GroupName = "BackOffice/User")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseUserUrl)]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Mediator"></param>
    public UserController(IMediator Mediator) => _mediator = Mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadOneUserUrl)]
    [PermissionPolicy(Type = Permission.UserReadOne)]
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
    [Route(Route.ReadAllPaginatedUserUrl)]
    [PermissionPolicy(Type = Permission.UserReadAllPaginated)]
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
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.CreateUserUrl)]
    [PermissionPolicy(Type = Permission.UserCreate)]
    public async Task<IActionResult> Create([FromBody] CreateCommand command, CancellationToken cancellationToken)
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
    [Route(Route.UpdateUserUrl)]
    [PermissionPolicy(Type = Permission.UserUpdate)]
    public async Task<IActionResult> Update([FromBody] UpdateCommand command, CancellationToken cancellationToken)
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
    [HttpPatch]
    [Route(Route.ActiveUserUrl)]
    [PermissionPolicy(Type = Permission.UserActive)]
    public async Task<IActionResult> Active([FromRoute] ActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<ActiveResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.InActiveUserUrl)]
    [PermissionPolicy(Type = Permission.ArticleInActive)]
    public async Task<IActionResult> InActive([FromRoute] InActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<InActiveResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}