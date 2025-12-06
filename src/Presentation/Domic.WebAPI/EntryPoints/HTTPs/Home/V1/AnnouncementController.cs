using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.AnnouncementUseCase.Commands.Active;
using Domic.UseCase.AnnouncementUseCase.Commands.Create;
using Domic.UseCase.AnnouncementUseCase.Commands.InActive;
using Domic.UseCase.AnnouncementUseCase.Commands.Update;
using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.AnnouncementUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AnnouncementUseCase.Queries.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Route                    = Domic.Common.ClassConsts.Route;
using ReadOneResponse          = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadAllPaginatedResponse = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using CreateResponse           = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Create.CreateResponse;
using UpdateResponse           = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update.UpdateResponse;
using ActiveResponse           = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Active.ActiveResponse;
using InActiveResponse         = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.InActive.InActiveResponse;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[Authorize(Roles = "SuperAdmin,Admin,Company")]
[ApiExplorerSettings(GroupName = "BackOffice/Announcement")]
[ApiVersion("1.0")]
[Route(Route.BaseHomeUrl + Route.BaseAnnouncementUrl)]
public sealed class AnnouncementController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadOneAnnouncementUrl)]
//  [PermissionPolicy(Type = "Term.ReadOne")]
    public async Task<IActionResult> ReadOne([FromRoute] ReadOneQuery query, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadAllPaginatedAnnouncementUrl)]
//  [PermissionPolicy(Type = "Term.ReadAllTransactionRequestPaginated")]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.CreateAnnouncementUrl)]
//  [PermissionPolicy(Type = "Term.Create")]
    public async Task<IActionResult> Create([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.UpdateAnnouncementUrl)]
//  [PermissionPolicy(Type = "Term.Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<UpdateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.ActiveAnnouncementUrl)]
//  [PermissionPolicy(Type = "Term.Active")]
    public async Task<IActionResult> Active([FromRoute] ActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<ActiveResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.InActiveAnnouncementUrl)]
//  [PermissionPolicy(Type = "Term.InActive")]
    public async Task<IActionResult> InActive([FromRoute] InActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<InActiveResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route(Route.DeleteAnnouncementUrl)]
//  [PermissionPolicy(Type = "Term.Delete")]
    public async Task<IActionResult> Delete([FromRoute] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}