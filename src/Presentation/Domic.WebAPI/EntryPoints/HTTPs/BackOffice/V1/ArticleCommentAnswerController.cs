using Domic.Core.Common.ClassConsts;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.ArticleCommentAnswerUseCase.Commands.Active;
using Domic.UseCase.ArticleCommentAnswerUseCase.Commands.Create;
using Domic.UseCase.ArticleCommentAnswerUseCase.Commands.Delete;
using Domic.UseCase.ArticleCommentAnswerUseCase.Commands.InActive;
using Domic.UseCase.ArticleCommentAnswerUseCase.Commands.Update;
using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Delete;
using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.ArticleCommentAnswerUseCase.DTOs.GRPCs.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/ArticleCommentAnswer")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseArticleCommentAnswerUrl)]
public class ArticleCommentAnswerController : ControllerBase
{
    private readonly IMediator _mediator;

    public ArticleCommentAnswerController(IMediator mediator) => _mediator = mediator;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
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
    [HttpDelete]
    [Route(Route.DeleteArticleCommentAnswerUrl)]
    [PermissionPolicy(Type = Permission.ArticleCommentAnswerDelete)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return new JsonResult(result);
    }
}