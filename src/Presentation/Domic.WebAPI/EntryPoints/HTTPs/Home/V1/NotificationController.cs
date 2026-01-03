using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.NotificationUseCase.Commands.Create;
using Domic.UseCase.NotificationUseCase.DTOs.GRPCs.Create;
using Microsoft.AspNetCore.Mvc;
using Domic.WebAPI.Frameworks.Extensions;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[ApiExplorerSettings(GroupName = "Home/Notification")]
[ApiVersion("1.0")]
[Route(Route.BaseHomeUrl + Route.BaseNotificationUrl)]
public class NotificationController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.SendEmailVerifyCodeNotificationUrl)]
    public async Task<IActionResult> SendEmailVerifyCode([FromBody] CreateCommand command, 
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}