using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SeasonUseCase.Commands.Active;
using Domic.UseCase.SeasonUseCase.Commands.Create;
using Domic.UseCase.SeasonUseCase.Commands.InActive;
using Domic.UseCase.SeasonUseCase.Commands.Update;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllBasedOnTermId;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.SeasonUseCase.Queries.ReadAllBasedOnTermId;
using Domic.UseCase.SeasonUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.SeasonUseCase.Queries.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Route                    = Domic.Common.ClassConsts.Route;
using ReadOneResponse          = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadAllPaginatedResponse = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using CreateResponse           = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Create.CreateResponse;
using UpdateResponse           = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Update.UpdateResponse;
using ActiveResponse           = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Active.ActiveResponse;
using InActiveResponse         = Domic.UseCase.SeasonUseCase.DTOs.GRPCs.InActive.InActiveResponse;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[ApiExplorerSettings(GroupName = "BackOffice/Season")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseSeasonUrl)]
public class SeasonController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadOneSeasonUrl)]
//  [PermissionPolicy(Type = "Term.ReadOne")]
    public async Task<IActionResult> ReadOne([FromRoute] ReadOneQuery query, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadAllSeasonBasedOnTermIdUrl)]
//  [PermissionPolicy(Type = "Term.ReadAllTransactionRequestPaginated")]
    public async Task<IActionResult> ReadAllBasedOneTermId([FromRoute] ReadAllBasedOnTermIdQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<ReadAllBasedOnTermIdResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadAllPaginatedSeasonUrl)]
//  [PermissionPolicy(Type = "Term.ReadAllTransactionRequestPaginated")]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.CreateSeasonUrl)]
//  [PermissionPolicy(Type = "Term.Create")]
    public async Task<IActionResult> Create([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.UpdateSeasonUrl)]
//  [PermissionPolicy(Type = "Term.Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<UpdateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.ActiveSeasonUrl)]
//  [PermissionPolicy(Type = "Term.Active")]
    public async Task<IActionResult> Active([FromRoute] ActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<ActiveResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.InActiveSeasonUrl)]
//  [PermissionPolicy(Type = "Term.InActive")]
    public async Task<IActionResult> InActive([FromRoute] InActiveCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<InActiveResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route(Route.DeleteSeasonUrl)]
//  [PermissionPolicy(Type = "Term.Delete")]
    public async Task<IActionResult> Delete([FromRoute] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}