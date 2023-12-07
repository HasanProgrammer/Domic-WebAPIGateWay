using Karami.Core.Common.ClassConsts;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.WebAPI.Filters;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Active;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Create;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Delete;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.InActive;
using Karami.UseCase.ArticleCommentAnswerUseCase.Commands.Update;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Active;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.InActive;
using Karami.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Karami.Common.ClassConsts.Route;

namespace Karami.WebAPI.EntryPoints.HTTPs.AdminPanel.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
public class ArticleCommentAnswerController : BaseArticleCommentAnswerController
{
    private readonly IMediator _mediator;

    public ArticleCommentAnswerController(IMediator mediator) => _mediator = mediator;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [Route(Route.CreateArticleCommentAnswerUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentAnswerCreate)]
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
    [PermissionPolicy(Type = Permission.ArticleCommentAnswerUpdate)]
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
    [Route(Route.ActiveArticleCommentAnswerUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentAnswerActive)]
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
    [Route(Route.InActiveArticleCommentAnswerUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentAnswerInActive)]
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
    [Route(Route.DeleteArticleCommentAnswerUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentAnswerDelete)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
}