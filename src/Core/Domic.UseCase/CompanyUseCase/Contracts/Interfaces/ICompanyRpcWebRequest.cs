using Domic.UseCase.CompanyUseCase.Commands.Active;
using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.CompanyUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.CompanyUseCase.Queries.ReadOne;
using Domic.UseCase.CompanyUseCase.Commands.Create;
using Domic.UseCase.CompanyUseCase.Commands.InActive;
using Domic.UseCase.CompanyUseCase.Commands.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.CompanyUseCase.Contracts.Interfaces;

public interface ICompanyRpcWebRequest : IRpcWebRequest
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