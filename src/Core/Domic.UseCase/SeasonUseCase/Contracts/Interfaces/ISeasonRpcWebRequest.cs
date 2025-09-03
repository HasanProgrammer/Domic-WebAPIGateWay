using Domic.UseCase.SeasonUseCase.Commands.Active;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.SeasonUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.SeasonUseCase.Queries.ReadOne;
using Domic.UseCase.SeasonUseCase.Commands.Create;
using Domic.UseCase.SeasonUseCase.Commands.InActive;
using Domic.UseCase.SeasonUseCase.Commands.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.SeasonUseCase.DTOs.GRPCs.ReadAllBasedOnTermId;
using Domic.UseCase.SeasonUseCase.Queries.ReadAllBasedOnTermId;

namespace Domic.UseCase.SeasonUseCase.Contracts.Interfaces;

public interface ISeasonRpcWebRequest : IRpcWebRequest
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