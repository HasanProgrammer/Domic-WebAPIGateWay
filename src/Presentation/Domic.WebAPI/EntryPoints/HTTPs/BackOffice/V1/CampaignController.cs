using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CampaignUseCase.Commands.Active;
using Domic.UseCase.CampaignUseCase.Commands.Create;
using Domic.UseCase.CampaignUseCase.Commands.Delete;
using Domic.UseCase.CampaignUseCase.Commands.InActive;
using Domic.UseCase.CampaignUseCase.Commands.Update;
using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Delete;
using Domic.UseCase.CampaignUseCase.Queries.ReadOne;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Route             = Domic.Common.ClassConsts.Route;
using ReadOneResponse   = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using CreateResponse    = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Create.CreateResponse;
using UpdateResponse    = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Update.UpdateResponse;
using ActiveResponse    = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Active.ActiveResponse;
using InActiveResponse  = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.InActive.InActiveResponse;

namespace Domic.WebAPI.EntryPoints.HTTPs.BackOffice.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[ApiExplorerSettings(GroupName = "BackOffice/Campaign")]
[ApiVersion("1.0")]
[Route(Route.BaseBackOfficeUrl + Route.BaseCampaignUrl)]
public class CampaignController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadOneCampaignUrl)]
//  [PermissionPolicy(Type = "Campaign.ReadOne")]
    public async Task<IActionResult> ReadOne([FromRoute] ReadOneQuery query, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.CreateCampaignUrl)]
//  [PermissionPolicy(Type = "Campaign.Create")]
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
    [Route(Route.UpdateCampaignUrl)]
//  [PermissionPolicy(Type = "Campaign.Update")]
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
    [Route(Route.ActiveCampaignUrl)]
//  [PermissionPolicy(Type = "Campaign.Active")]
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
    [Route(Route.InActiveCampaignUrl)]
//  [PermissionPolicy(Type = "Campaign.InActive")]
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
    [Route(Route.DeleteCampaignUrl)]
//  [PermissionPolicy(Type = "Campaign.Delete")]
    public async Task<IActionResult> Delete([FromRoute] DeleteCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<DeleteResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}