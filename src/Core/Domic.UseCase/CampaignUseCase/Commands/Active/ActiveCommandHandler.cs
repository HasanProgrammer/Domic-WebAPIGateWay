using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Active;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CampaignUseCase.Contracts.Interfaces;

namespace Domic.UseCase.CampaignUseCase.Commands.Active;

public class ActiveCommandHandler(ICampaignRpcWebRequest campaignRpcWebRequest) : ICommandHandler<ActiveCommand, ActiveResponse>
{
    public Task BeforeHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<ActiveResponse> HandleAsync(ActiveCommand command, CancellationToken cancellationToken) 
        => campaignRpcWebRequest.ActiveAsync(command, cancellationToken);

    public Task AfterHandleAsync(ActiveCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}