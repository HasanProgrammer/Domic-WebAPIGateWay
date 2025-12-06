using Domic.Core.Campaign.Grpc;
using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.CampaignUseCase.Contracts.Interfaces;
using Domic.UseCase.CampaignUseCase.Commands.Create;
using Domic.UseCase.CampaignUseCase.Commands.Delete;
using Domic.UseCase.CampaignUseCase.Commands.Update;
using Domic.UseCase.CampaignUseCase.DTOs;
using Domic.UseCase.CampaignUseCase.Queries.ReadOne;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;

using CheckExistRequest       = Domic.Core.Campaign.Grpc.CheckExistRequest;
using CreateRequest           = Domic.Core.Campaign.Grpc.CreateRequest;
using String                  = Domic.Core.Campaign.Grpc.String;
using CreateResponse          = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody      = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using DeleteRequest           = Domic.Core.Campaign.Grpc.DeleteRequest;
using DeleteResponse          = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody      = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using ReadOneRequest          = Domic.Core.Campaign.Grpc.ReadOneRequest;
using ReadOneResponse         = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody     = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using UpdateRequest           = Domic.Core.Campaign.Grpc.UpdateRequest;
using UpdateResponse          = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody      = Domic.UseCase.CampaignUseCase.DTOs.GRPCs.Update.UpdateResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class CampaignRpcWebRequest : ICampaignRpcWebRequest
{
    private readonly IServiceDiscovery         _serviceDiscovery;
    private readonly IExternalDistributedCache _distributedCache;
    private readonly IHttpContextAccessor      _httpContextAccessor;

    private GrpcChannel _channel;

    public CampaignRpcWebRequest(IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery, IExternalDistributedCache distributedCache
    )
    {
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
        _distributedCache    = distributedCache;
    }

    public async Task<bool> CheckExistAsync(string id, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        CheckExistRequest payload = new();

        payload.Id = id is not null ? new String { Value = id } : null;

        var result = 
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return result.Result;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadOneRequest payload = new() {
            Id = request.Id != null ? new String { Value = request.Id } : null
        };

        var result =
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { Campaign = result.Body.Campaign.DeSerialize<CampaignDto>() } 
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();
        
        payload.Title = !string.IsNullOrEmpty(request.Title) ? new String { Value = request.Title } : null;
        payload.Description = !string.IsNullOrEmpty(request.Description) ? new String { Value = request.Description } : null;
        payload.StartDate = request.StartDate.ToTimestamp();
        payload.EndDate = request.StartDate.ToTimestamp();
        payload.DiscountPercentage = Convert.ToInt64(request.DiscountPercentage);
        payload.Terms = new String { Value = request.Terms.Serialize() };
        
        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { Id = result.Body.Id }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new() {
            Id = new String { Value = request.Id }
        };
        
        payload.Title = !string.IsNullOrEmpty(request.Title) ? new String { Value = request.Title } : null;
        payload.Description = !string.IsNullOrEmpty(request.Description) ? new String { Value = request.Description } : null;
        payload.StartDate = request.StartDate.ToTimestamp();
        payload.EndDate = request.StartDate.ToTimestamp();
        payload.DiscountPercentage = Convert.ToInt64(request.DiscountPercentage);
        payload.Terms = new String { Value = request.Terms.Serialize() };

        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { Id = result.Body.Id }
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        DeleteRequest payload = new() {
            Id = request.Id is not null ? new String { Value = request.Id } : null
        };

        var result =
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { Id = result.Body.Id }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, CampaignService.CampaignServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask = 
            _serviceDiscovery.LoadAddressInMemoryAsync(Service.TermService, cancellationToken);

        var secretKeyTask = _distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.License , await secretKeyTask }
        };
        
        var token = _httpContextAccessor.HttpContext.GetRowToken();
        
        if(token is not null)
            metaData.Add(Header.Token, token);
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new CampaignService.CampaignServiceClient(_channel) );
    }
}