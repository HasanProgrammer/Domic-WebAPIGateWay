using Domic.UseCase.CampaignUseCase.Contracts.Interfaces;
using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Delete;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CampaignUseCase.Commands.Delete;

public class DeleteCommandHandler(ICampaignRpcWebRequest campaignRpcWebRequest) : ICommandHandler<DeleteCommand, DeleteResponse>
{
    public Task BeforeHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<DeleteResponse> HandleAsync(DeleteCommand command, CancellationToken cancellationToken) 
        => campaignRpcWebRequest.DeleteAsync(command, cancellationToken);

    public Task AfterHandleAsync(DeleteCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}