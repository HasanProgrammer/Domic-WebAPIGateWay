using Domic.UseCase.AnnouncementUseCase.Commands.Active;
using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.AnnouncementUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AnnouncementUseCase.Queries.ReadOne;
using Domic.UseCase.AnnouncementUseCase.Commands.Create;
using Domic.UseCase.AnnouncementUseCase.Commands.InActive;
using Domic.UseCase.AnnouncementUseCase.Commands.Update;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.AnnouncementUseCase.Contracts.Interfaces;

public interface IAnnouncementRpcWebRequest : IRpcWebRequest
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