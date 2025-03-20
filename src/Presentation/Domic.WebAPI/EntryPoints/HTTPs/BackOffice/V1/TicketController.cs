using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.TicketUseCase.Commands.Update;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Route            = Domic.Common.ClassConsts.Route;
using UpdateResponse   = Domic.UseCase.TicketUseCase.DTOs.GRPCs.Update.UpdateResponse;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[ApiExplorerSettings(GroupName = "BackOffice/Ticket")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseTicketUrl)]
public class TicketController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.UpdateTicketUrl)]
    [PermissionPolicy(Type = "Ticket.Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<UpdateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);;
    }
}