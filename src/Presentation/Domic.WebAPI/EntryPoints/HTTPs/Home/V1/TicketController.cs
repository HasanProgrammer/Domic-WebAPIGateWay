using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.Commands.Create;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateTicketUseCase.Queries.ReadOne;
using Domic.UseCase.TicketUseCase.Commands.CreateComment;
using Domic.UseCase.TicketUseCase.DTOs.GRPCs.CreateComment;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route                    = Domic.Common.ClassConsts.Route;
using ReadOneResponse          = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadAllPaginatedResponse = Domic.UseCase.AggregateTicketUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using CreateResponse           = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Create.CreateResponse;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[Authorize]
[ApiExplorerSettings(GroupName = "Home/Ticket")]
[Route($"{Route.BaseHomeUrl}{Route.BaseAggregateTicketUrl}")]
[ApiVersion("1.0")]
public class TicketController(IMediator mediator, [FromKeyedServices("Http1")] IIdentityUser identityUser) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadOneAggregateTicketUrl)] 
  //[PermissionPolicy(Type = "AggregateTicket.ReadOne")]
    public async Task<IActionResult> ReadOne([FromRoute] ReadOneQuery query, CancellationToken cancellationToken)
    {
        if(!identityUser.GetRoles().Contains("SuperAdmin") || !identityUser.GetRoles().Contains("Admin"))
            query.UserId = identityUser.GetIdentity();
        
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
    [Route(Route.ReadAllPaginatedAggregateTicketUrl)]
  //[PermissionPolicy(Type = "AggregateTicket.ReadAllPaginated")]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        if(!identityUser.GetRoles().Contains("SuperAdmin") || !identityUser.GetRoles().Contains("Admin"))
            query.UserId = identityUser.GetIdentity();
        
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
    [Route(Route.CreateTicketUrl)]
  //[PermissionPolicy(Type = "Ticket.Create")]
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
    [HttpPost(Route.CreateTicketCommentUrl)]
   //[PermissionPolicy(Type = "Ticket.CreateComment")]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<CreateCommentResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}