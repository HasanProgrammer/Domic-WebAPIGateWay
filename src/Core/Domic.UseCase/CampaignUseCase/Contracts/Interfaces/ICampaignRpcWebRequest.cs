using Domic.UseCase.CampaignUseCase.Commands.Active;
using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Active;
using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Create;
using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.InActive;
using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.ReadOne;
using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Update;
using Domic.UseCase.CampaignUseCase.Queries.ReadOne;
using Domic.UseCase.CampaignUseCase.Commands.Create;
using Domic.UseCase.CampaignUseCase.Commands.InActive;
using Domic.UseCase.CampaignUseCase.Commands.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.CampaignUseCase.Commands.Delete;
using Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Delete;

namespace Domic.UseCase.CampaignUseCase.Contracts.Interfaces;

public interface ICampaignRpcWebRequest : IRpcWebRequest
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