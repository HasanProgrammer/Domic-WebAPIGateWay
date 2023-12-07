#pragma warning disable CS4014

using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.Create;

namespace Karami.UseCase.UserUseCase.Commands.Create;

public class CreateCommandHandler : ICommandHandler<CreateCommand, CreateResponse>
{
    private readonly IUserRpcWebRequest _userRpcWebRequest;
    
    public CreateCommandHandler(IUserRpcWebRequest userRpcWebRequest) => _userRpcWebRequest = userRpcWebRequest;
    
    public async Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken) 
        => await _userRpcWebRequest.CreateAsync(command, cancellationToken);
}