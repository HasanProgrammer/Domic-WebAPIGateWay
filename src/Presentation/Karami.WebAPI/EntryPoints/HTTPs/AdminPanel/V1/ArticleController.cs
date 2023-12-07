using Karami.Core.Common.ClassConsts;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.WebAPI.Filters;
using Karami.UseCase.ArticleUseCase.Commands.Active;
using Karami.UseCase.ArticleUseCase.Commands.Create;
using Karami.UseCase.ArticleUseCase.Commands.Delete;
using Karami.UseCase.ArticleUseCase.Commands.InActive;
using Karami.UseCase.ArticleUseCase.Commands.Update;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Active;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Delete;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.InActive;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.ArticleUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.ArticleUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.ArticleUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Karami.Common.ClassConsts.Route;

namespace Karami.WebAPI.EntryPoints.HTTPs.AdminPanel.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
public class ArticleController : BaseArticleController
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
    public async Task<IActionResult> ReadOne([FromQuery] ReadOneQuery query,
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
    [HttpPut]
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
    [HttpPatch]
    [Route(Route.DeleteArticleUrl)]
    [PermissionPolicy(Type = Permission.ArticleDelete)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);
    
        return new JsonResult(result);
    }
}