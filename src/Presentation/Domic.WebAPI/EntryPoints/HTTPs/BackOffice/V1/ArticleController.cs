using Domic.Core.Common.ClassConsts;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.ArticleUseCase.Commands.Active;
using Domic.UseCase.ArticleUseCase.Commands.Create;
using Domic.UseCase.ArticleUseCase.Commands.Delete;
using Domic.UseCase.ArticleUseCase.Commands.InActive;
using Domic.UseCase.ArticleUseCase.Commands.Update;
using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Delete;
using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.ArticleUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.ArticleUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.ArticleUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
[ApiExplorerSettings(GroupName = "BackOffice/Article")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseArticleUrl)]
public class ArticleController : ControllerBase
{
    private readonly IMediator _mediator;

    public ArticleController(IMediator mediator) => _mediator = mediator;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadOneArticleUrl)]
    [PermissionPolicy(Type = Permission.ArticleReadOne)]
    public async Task<IActionResult> ReadOne([FromRoute] ReadOneQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadAllPaginatedArticleUrl)]
    [PermissionPolicy(Type = Permission.ArticleReadAllPaginated)]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return new JsonResult(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.CreateArticleUrl)]
    [PermissionPolicy(Type = Permission.ArticleCreate)]
    public async Task<IActionResult> Create([FromForm] CreateCommand command, CancellationToken cancellationToken)
    {
        command.UserId = HttpContext.GetIdentityUserId().ToString();
        
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
    [Route(Route.UpdateArticleUrl)]
    [PermissionPolicy(Type = Permission.ArticleUpdate)]
    public async Task<IActionResult> Update([FromForm] UpdateCommand command, CancellationToken cancellationToken)
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
    [Route(Route.ActiveArticleUrl)]
    [PermissionPolicy(Type = Permission.ArticleActive)]
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
    [Route(Route.InActiveArticleUrl)]
    [PermissionPolicy(Type = Permission.ArticleInActive)]
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
    [Route(Route.DeleteArticleUrl)]
    [PermissionPolicy(Type = Permission.ArticleDelete)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);
    
        return new JsonResult(result);
    }
}