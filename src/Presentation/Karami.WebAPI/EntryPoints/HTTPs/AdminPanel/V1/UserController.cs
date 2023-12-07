using Karami.Core.Common.ClassConsts;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.WebAPI.Filters;
using Karami.UseCase.UserUseCase.Commands.Active;
using Karami.UseCase.UserUseCase.Commands.Create;
using Karami.UseCase.UserUseCase.Commands.InActive;
using Karami.UseCase.UserUseCase.Commands.Revoke;
using Karami.UseCase.UserUseCase.Commands.SignIn;
using Karami.UseCase.UserUseCase.Commands.Update;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.SignIn;
using Karami.UseCase.UserUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.UserUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Route                    = Karami.Common.ClassConsts.Route;
using ReadOneResponse          = Karami.UseCase.UserUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadAllPaginatedResponse = Karami.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using CreateResponse           = Karami.UseCase.UserUseCase.DTOs.GRPCs.Create.CreateResponse;
using UpdateResponse           = Karami.UseCase.UserUseCase.DTOs.GRPCs.Update.UpdateResponse;
using ActiveResponse           = Karami.UseCase.UserUseCase.DTOs.GRPCs.Active.ActiveResponse;
using InActiveResponse         = Karami.UseCase.UserUseCase.DTOs.GRPCs.InActive.InActiveResponse;

namespace Karami.WebAPI.EntryPoints.HTTPs.AdminPanel.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy(IgnoreActions = "SignIn")]
public class UserController : BaseUserController
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
    [Route(Route.ReadAllPaginatedUserUrl)]
    [PermissionPolicy(Type = Permission.UserReadAllPaginated)]
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
    [Route(Route.CreateUserUrl)]
    [PermissionPolicy(Type = Permission.UserCreate)]
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
    [Route(Route.UpdateUserUrl)]
    [PermissionPolicy(Type = Permission.UserUpdate)]
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
    [Route(Route.ActiveUserUrl)]
    [PermissionPolicy(Type = Permission.UserActive)]
    public async Task<IActionResult> Active([FromBody] ActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<ActiveResponse>(command, cancellationToken);

        return new JsonResult(result);
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
    public async Task<IActionResult> InActive([FromBody] InActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<InActiveResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.RevokeUrl)]
    [PermissionPolicy(Type = Permission.UserRevoke)]
    public async Task<IActionResult> Revoke([FromBody] RevokeCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<bool>(command, cancellationToken);

        return result ? 
            new JsonResult(new { Code = 200, Message = "عملیات ابطال دسترسی با موفقیت انجام گردید" , Body = new {} }): 
            new JsonResult(new { Code = 400, Message = "عملیات ابطال دسترسی با موفقیت انجام نگردید", Body = new {} });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.SignInUserUrl)]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<SignInResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
}