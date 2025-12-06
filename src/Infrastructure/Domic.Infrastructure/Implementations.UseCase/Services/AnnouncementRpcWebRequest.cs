using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.Announcement.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.AnnouncementUseCase.Contracts.Interfaces;
using Domic.UseCase.AnnouncementUseCase.Commands.Active;
using Domic.UseCase.AnnouncementUseCase.Commands.Update;
using Domic.UseCase.AnnouncementUseCase.Commands.Create;
using Domic.UseCase.AnnouncementUseCase.Commands.InActive;
using Domic.UseCase.AnnouncementUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AnnouncementUseCase.Queries.ReadOne;
using Domic.UseCase.AnnouncementUseCase.Contracts.Interfaces;
using Domic.UseCase.AnnouncementUseCase.DTOs;
using Microsoft.AspNetCore.Http;

using String                           = Domic.Core.Announcement.Grpc.String;
using Int32                            = Domic.Core.Announcement.Grpc.Int32;
using ActiveRequest                    = Domic.Core.Announcement.Grpc.ActiveRequest;
using CheckExistRequest                = Domic.Core.Announcement.Grpc.CheckExistRequest;
using CreateRequest                    = Domic.Core.Announcement.Grpc.CreateRequest;
using InActiveRequest                  = Domic.Core.Announcement.Grpc.InActiveRequest;
using ReadAllPaginatedRequest          = Domic.Core.Announcement.Grpc.ReadAllPaginatedRequest;
using ReadOneRequest                   = Domic.Core.Announcement.Grpc.ReadOneRequest;
using UpdateRequest                    = Domic.Core.Announcement.Grpc.UpdateRequest;
using ReadOneResponse                  = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody              = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using CreateResponse                   = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody               = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using ReadAllPaginatedResponse         = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody     = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using UpdateResponse                   = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody               = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse                   = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody               = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using DeleteResponse                   = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update.DeleteResponse;
using DeleteResponseBody               = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.Update.DeleteResponseBody;
using InActiveResponse                 = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody             = Domic.UseCase.AnnouncementUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class AnnouncementRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor,
    IExternalDistributedCache distributedCache
) : IAnnouncementRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<bool> CheckExistAsync(string id, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        CheckExistRequest payload = new() { Id = !string.IsNullOrEmpty(id) ? new String { Value = id } : null };

        var result =
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return result.Result;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadOneRequest payload = new() {
            Id = request.Id != null ? new String { Value = request.Id } : null
        };

        var result =
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { Announcement = result.Body.Announcement.DeSerialize<AnnouncementDto>() } 
        };
    }

    /*public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            PageNumber   = request.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null ,
            CountPerPage = request.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null
        };
        
        var result =
            await loadData.client.ReadAllPaginatedAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Seasons = result.Body.Seasons.DeSerialize<PaginatedCollection<SeasonDto>>()
            }
        };
    }*/

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();

        payload.Title = !string.IsNullOrEmpty(request.Title) ? new String { Value = request.Title } : null;
        payload.CompanyId = !string.IsNullOrEmpty(request.CompanyId) ? new String { Value = request.CompanyId } : null;
        payload.StackId = !string.IsNullOrEmpty(request.StackId) ? new String { Value = request.StackId } : null;
        payload.Budget = request.Budget != null ? new Int32 { Value = request.Budget.Value } : null;
        payload.Position = request.Position != null ? new Int32 { Value = (int)request.Position.Value } : null;
        
        if(request.Skills.Any() || request.Skills != null) 
            payload.Skills.AddRange(request.Skills);
        
        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { Id = result.Body.AnnouncementId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();

        payload.Id = !string.IsNullOrEmpty(request.Id) ? new String { Value = request.Id } : null;
        payload.Title = !string.IsNullOrEmpty(request.Title) ? new String { Value = request.Title } : null;
        payload.CompanyId = !string.IsNullOrEmpty(request.CompanyId) ? new String { Value = request.CompanyId } : null;
        payload.StackId = !string.IsNullOrEmpty(request.StackId) ? new String { Value = request.StackId } : null;
        payload.Budget = request.Budget != null ? new Int32 { Value = request.Budget.Value } : null;
        payload.Position = request.Position != null ? new Int32 { Value = (int)request.Position.Value } : null;
        
        if(request.Skills.Any() || request.Skills != null)
            payload.Skills.AddRange(request.Skills);
        
        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { Id = result.Body.AnnouncementId }
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        DeleteRequest payload = new();

        payload.Id = !string.IsNullOrEmpty(request.Id ) ? new String { Value = request.Id } : null;

        var result =
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { Id = result.Body.AnnouncementId } 
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        ActiveRequest payload = new();

        payload.Id = !string.IsNullOrEmpty(request.Id) ? new String { Value = request.Id } : null;

        var result =
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { Id = result.Body.AnnouncementId } 
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        InActiveRequest payload = new();

        payload.Id = !string.IsNullOrEmpty(request.Id) ? new String { Value = request.Id } : null;

        var result =
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { Id = result.Body.AnnouncementId } 
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, AnnouncementService.AnnouncementServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask =
            serviceDiscovery.LoadAddressInMemoryAsync("HumanResourceService", cancellationToken);
        
        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());
        
        var metaData = new Metadata {
            { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(!isIdempotent)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new AnnouncementService.AnnouncementServiceClient(_channel) );
    }
}