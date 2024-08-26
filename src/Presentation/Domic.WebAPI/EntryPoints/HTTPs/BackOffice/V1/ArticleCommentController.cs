using Domic.Core.Common.ClassConsts;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.ArticleCommentUseCase.Commands.Active;
using Domic.UseCase.ArticleCommentUseCase.Commands.Create;
using Domic.UseCase.ArticleCommentUseCase.Commands.Delete;
using Domic.UseCase.ArticleCommentUseCase.Commands.InActive;
using Domic.UseCase.ArticleCommentUseCase.Commands.Update;
using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Delete;
using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
[Route(Route.BaseBackOfficeUrl + Route.BaseArticleCommentUrl)]
public class ArticleCommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public ArticleCommentController(IMediator mediator) => _mediator = mediator;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [Route(Route.CreateArticleCommentUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentCreate)]
    public async Task<IActionResult> Create([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        command.OwnerId = HttpContext.GetIdentityUserId().ToString();
        
        var result = await _mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.UpdateArticleCommentUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentUpdate)]
    public async Task<IActionResult> Update([FromBody] UpdateCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<UpdateResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.ActiveArticleCommentUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentActive)]
    public async Task<IActionResult> Active([FromBody] ActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<ActiveResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.InActiveArticleCommentUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentInActive)]
    public async Task<IActionResult> InActive([FromBody] InActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<InActiveResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route(Route.DeleteArticleCommentUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentDelete)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
}