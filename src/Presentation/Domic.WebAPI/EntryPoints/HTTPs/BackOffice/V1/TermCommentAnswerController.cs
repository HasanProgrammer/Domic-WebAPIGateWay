using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Active;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Create;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Delete;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.InActive;
using Domic.UseCase.TermCommentAnswerUseCase.Commands.Update;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Delete;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.Update;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/TermCommentAnswer")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseTermCommentAnswerUrl)]
public class TermCommentAnswerController : ControllerBase
{
    private readonly IMediator _mediator;

    public TermCommentAnswerController(IMediator mediator) => _mediator = mediator;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.CreateTermCommentAnswerUrl)]
    //[PermissionPolicy(Type = Permission.TermCommentCreate)]
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
    [Route(Route.UpdateTermCommentAnswerUrl)]
    //[PermissionPolicy(Type = Permission.TermCommentUpdate)]
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
    [Route(Route.ActiveTermCommentAnswerUrl)]
    //[PermissionPolicy(Type = Permission.TermCommentActive)]
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
    [Route(Route.InActiveTermCommentAnswerUrl)]
    //[PermissionPolicy(Type = Permission.TermCommentInActive)]
    public async Task<IActionResult> InActive([FromRoute] InActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<InActiveResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route(Route.DeleteTermCommentAnswerUrl)]
    //[PermissionPolicy(Type = Permission.TermCommentDelete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}