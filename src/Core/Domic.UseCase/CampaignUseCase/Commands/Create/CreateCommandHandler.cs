#pragma warning disable CS4014

using Domic.Core.UseCase.Attributes;
using Domic.UseCase.CampaignUseCase.Contracts.Interfaces;
using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CampaignUseCase.Commands.Create;

public class CreateCommandHandler(ICampaignRpcWebRequest campaignRpcWebRequest) : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithValidation]
    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken) 
        => campaignRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}