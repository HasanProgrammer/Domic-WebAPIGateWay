using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.FinancialUseCase.Commands.Create;
using Domic.UseCase.FinancialUseCase.Commands.PaymentVerification;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[ApiExplorerSettings(GroupName = "Home/Financial")]
[ApiVersion("1.0")]
[Route(Route.BaseHomeUrl + Route.BaseFinancialUrl)]
public class FinancialController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// new transaction
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.CreateFinancialUrl)]
    public async Task<IActionResult> Create([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync(command, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// verification purchase ( from bank gateway )
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.UpdateFinancialUrl)]
    public async Task<IActionResult> PaymentVerification([FromBody] PaymentVerificationCommand command, 
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync(command, cancellationToken);

        return new JsonResult(result);
    }
}