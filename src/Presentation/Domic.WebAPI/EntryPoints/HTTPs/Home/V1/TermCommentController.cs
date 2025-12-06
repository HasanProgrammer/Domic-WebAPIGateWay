using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.TermCommentUseCase.Commands.Create;
using Domic.UseCase.TermCommentUseCase.DTOs.GRPCs.Create;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[Authorize]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "Home/TermComment")]
[ApiVersion("1.0")]
[Route(Route.BaseHomeUrl + Route.BaseTermCommentUrl)]
public class TermCommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public TermCommentController(IMediator mediator) => _mediator = mediator;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.CreateTermCommentUrl)]
    //[PermissionPolicy(Type = Permission.TermCommentCreate)]
    public async Task<IActionResult> Create([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}