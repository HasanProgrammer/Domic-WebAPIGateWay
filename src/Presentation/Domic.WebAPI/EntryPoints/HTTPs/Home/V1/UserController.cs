using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.Commands.Create;
using Domic.UseCase.UserUseCase.Commands.OtpGeneration;
using Domic.UseCase.UserUseCase.Commands.OtpVerification;
using Domic.UseCase.UserUseCase.Commands.SignIn;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.SignIn;
using Microsoft.AspNetCore.Mvc;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpGeneration;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpVerification;
using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[ApiExplorerSettings(GroupName = "Home/User")]
[ApiVersion("1.0")]
[Route(Route.BaseHomeUrl + Route.BaseUserUrl)]
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
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.SignInUserUrl)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<SignInResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.OtpGenerationUserUrl)]
    public async Task<IActionResult> OtpGeneration([FromBody] OtpGenerationCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.DispatchAsync<OtpGenerationResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.OtpVerificationUserUrl)]
    public async Task<IActionResult> OtpVerification([FromBody] OtpVerificationCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.DispatchAsync<OtpVerificationResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.SignUpUserUrl)]
    public async Task<IActionResult> SignUp([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
}