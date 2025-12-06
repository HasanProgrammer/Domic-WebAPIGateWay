using Domic.UseCase.StackUseCase.Commands.Active;
using Domic.UseCase.StackUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.StackUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.StackUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.StackUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.StackUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.StackUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.StackUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.StackUseCase.Queries.ReadOne;
using Domic.UseCase.StackUseCase.Commands.Create;
using Domic.UseCase.StackUseCase.Commands.InActive;
using Domic.UseCase.StackUseCase.Commands.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllBasedOnTermId;
using Domic.UseCase.SeasonUseCase.Queries.ReadAllBasedOnTermId;

namespace Domic.UseCase.StackUseCase.Contracts.Interfaces;

public interface IStackRpcWebRequest : IRpcWebRequest
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
    public Task<ReadAllBasedOnTermIdResponse> ReadAllBasedOnTermIdAsync(ReadAllBasedOnTermIdQuery request,
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
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
    public Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
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