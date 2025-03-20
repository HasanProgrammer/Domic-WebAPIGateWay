using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.Queries.ReadOne;
using Domic.UseCase.UserUseCase.Commands.Create;
using Domic.UseCase.UserUseCase.Commands.OtpGeneration;
using Domic.UseCase.UserUseCase.Commands.OtpVerification;
using Domic.UseCase.UserUseCase.Commands.SignIn;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.SignIn;
using Microsoft.AspNetCore.Mvc;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpGeneration;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpVerification;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[ApiExplorerSettings(GroupName = "Home/User")]
[ApiVersion("1.0")]
[Route(Route.BaseHomeUrl + Route.BaseUserUrl)]
public class UserController(IMediator mediator, [FromKeyedServices("Http1")] IIdentityUser identityUser) : ControllerBase
{
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
        var result = await mediator.DispatchAsync<SignInResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
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
        var result = await mediator.DispatchAsync<OtpGenerationResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);;
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
        var result = await mediator.DispatchAsync<OtpVerificationResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);;
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
        var result = await mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet(Route.ProfileUserUrl)]
    public async Task<IActionResult> GetUserProfile(CancellationToken cancellationToken)
    {
        var query = new ReadOneQuery { Id = identityUser.GetIdentity() };
        
        var result = await mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);;
    }
}