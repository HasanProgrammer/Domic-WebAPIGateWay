#pragma warning disable CS4014

using Domic.UseCase.UserUseCase.Contracts.Interfaces;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.UserUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;
    
    public CreateCommandHandler(IUserRpcWebRequest userRpcWebRequest) => _userRpcWebRequest = userRpcWebRequest;

    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken) 
        => await _userRpcWebRequest.CreateAsync(command, cancellationToken);
}