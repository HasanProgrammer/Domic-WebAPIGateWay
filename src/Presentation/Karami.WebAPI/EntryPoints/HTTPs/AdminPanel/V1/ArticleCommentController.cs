using Karami.Core.Common.ClassConsts;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.WebAPI.Filters;
using Karami.UseCase.ArticleCommentUseCase.Commands.Active;
using Karami.UseCase.ArticleCommentUseCase.Commands.Create;
using Karami.UseCase.ArticleCommentUseCase.Commands.Delete;
using Karami.UseCase.ArticleCommentUseCase.Commands.InActive;
using Karami.UseCase.ArticleCommentUseCase.Commands.Update;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.InActive;
using Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Karami.Common.ClassConsts.Route;

namespace Karami.WebAPI.EntryPoints.HTTPs.AdminPanel.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
public class ArticleCommentController : BaseArticleCommentController
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
    [HttpPatch]
    [Route(Route.DeleteArticleCommentUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentDelete)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
}