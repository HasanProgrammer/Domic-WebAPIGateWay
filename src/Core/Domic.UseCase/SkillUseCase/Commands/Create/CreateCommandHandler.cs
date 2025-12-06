#pragma warning disable CS4014

using Domic.UseCase.SkillUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SkillUseCase.Contracts.Interfaces;

namespace Domic.UseCase.SkillUseCase.Commands.Create;

public sealed class CreateCommandHandler(ISkillRpcWebRequest skillRpcWebRequest) : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken) 
        => skillRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}