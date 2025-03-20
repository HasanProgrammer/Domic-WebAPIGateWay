using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.FinancialUseCase.Commands.ChangeStatusTransactionRequest;
using Domic.UseCase.FinancialUseCase.Commands.Create;
using Domic.UseCase.FinancialUseCase.Commands.CreateTransactionRequest;
using Domic.UseCase.FinancialUseCase.Commands.DecreaseAccountBalance;
using Domic.UseCase.FinancialUseCase.Commands.PaymentVerification;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[Authorize]
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
    [PermissionPolicy(Type = "Financial.Create")]
    public async Task<IActionResult> Create([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync(command, cancellationToken);

        return HttpContext.OkResponse(result);;
    }
    
    /// <summary>
    /// verification purchase ( from bank gateway )
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.UpdateFinancialUrl)]
    [PermissionPolicy(Type = "Financial.PaymentVerification")]
    public async Task<IActionResult> PaymentVerification([FromBody] PaymentVerificationCommand command, 
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync(command, cancellationToken);

        return HttpContext.OkResponse(result);;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.CreateTransactionRequestFinancialUrl)]
    [PermissionPolicy(Type = "Financial.CreateTransactionRequest")]
    public async Task<IActionResult> CreateTransactionRequest([FromBody] CreateTransactionRequestCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync(command, cancellationToken);

        return HttpContext.OkResponse(result);;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.ChangeStatusTransactionRequestFinancialUrl)]
    [PermissionPolicy(Type = "Financial.ChangeStatusTransactionRequest")]
    public async Task<IActionResult> ChangeStatusTransactionRequest(
        [FromBody] ChangeStatusTransactionRequestCommand command, CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync(command, cancellationToken);

        return HttpContext.OkResponse(result);;
    }
    
    /// <summary>
    /// todo: for test
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.DecreaseWalletFinancialUrl)]
    [PermissionPolicy(Type = "Financial.DecreaseWallet")]
    public async Task<IActionResult> DecreaseWallet(
        [FromBody] DecreaseAccountBalanceCommand command, CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync(command, cancellationToken);

        return HttpContext.OkResponse(result);;
    }
}