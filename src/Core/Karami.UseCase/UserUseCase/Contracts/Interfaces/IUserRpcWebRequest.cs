using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Commands.Active;
using Karami.UseCase.UserUseCase.Commands.Update;
using Karami.UseCase.UserUseCase.Commands.Create;
using Karami.UseCase.UserUseCase.Commands.InActive;
using Karami.UseCase.UserUseCase.Commands.SignIn;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.Active;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.Create;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.InActive;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.ReadAllPaginated;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.ReadOne;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.SignIn;
using Karami.UseCase.UserUseCase.DTOs.GRPCs.Update;
using Karami.UseCase.UserUseCase.Queries.ReadAllPaginated;
using Karami.UseCase.UserUseCase.Queries.ReadOne;

namespace Karami.UseCase.UserUseCase.Contracts.Interfaces;

public interface IUserRpcWebRequest : IRpcWebRequest
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<SignInResponse> SignInAsync(SignInCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}