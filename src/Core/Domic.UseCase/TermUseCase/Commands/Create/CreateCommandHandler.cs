#pragma warning disable CS4014

using Domic.UseCase.TermUseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Commands.Create;

public class CreateCommandHandler(ITermRpcWebRequest termRpcWebRequest) : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken) 
        => termRpcWebRequest.CreateAsync(command, cancellationToken);
}