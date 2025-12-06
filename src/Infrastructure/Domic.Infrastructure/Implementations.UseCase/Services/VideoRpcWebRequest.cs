using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.Video.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.VideoUseCase.Contracts.Interfaces;
using Domic.UseCase.VideoUseCase.Commands.Active;
using Domic.UseCase.VideoUseCase.Commands.Update;
using Domic.UseCase.VideoUseCase.Commands.Create;
using Domic.UseCase.VideoUseCase.Commands.InActive;
using Domic.UseCase.VideoUseCase.DTOs;
using Domic.UseCase.VideoUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.VideoUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;
using String                       = Domic.Core.Video.Grpc.String;
using Int32                        = Domic.Core.Video.Grpc.Int32;
using ActiveRequest                = Domic.Core.Video.Grpc.ActiveRequest;
using ReadOneResponse              = Domic.UseCase.VideoUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.VideoUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using CreateResponse               = Domic.UseCase.VideoUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody           = Domic.UseCase.VideoUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using ReadAllPaginatedResponse     = Domic.UseCase.VideoUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.VideoUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using UpdateResponse               = Domic.UseCase.VideoUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody           = Domic.UseCase.VideoUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse               = Domic.UseCase.VideoUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody           = Domic.UseCase.VideoUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using CheckExistRequest            = Domic.Core.Video.Grpc.CheckExistRequest;
using CreateRequest                = Domic.Core.Video.Grpc.CreateRequest;
using DeleteResponse = Domic.UseCase.VideoUseCase.DTOs.GRPCs.Update.DeleteResponse;
using DeleteResponseBody = Domic.UseCase.VideoUseCase.DTOs.GRPCs.Update.DeleteResponseBody;
using InActiveRequest              = Domic.Core.Video.Grpc.InActiveRequest;
using InActiveResponse             = Domic.UseCase.VideoUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody         = Domic.UseCase.VideoUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;
using ReadAllPaginatedRequest      = Domic.Core.Video.Grpc.ReadAllPaginatedRequest;
using ReadOneRequest               = Domic.Core.Video.Grpc.ReadOneRequest;
using UpdateRequest                = Domic.Core.Video.Grpc.UpdateRequest;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class VideoRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor,
    IExternalDistributedCache distributedCache
) : IVideoRpcWebRequest
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
            Body    = new ReadOneResponseBody { Video = result.Body.Video.DeSerialize<VideoDto>() } 
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
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
                Videos = result.Body.Videos.DeSerialize<PaginatedCollection<VideoDto>>()
            }
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();

        payload.SeasonId    = request.SeasonId    != null ? new String { Value = request.SeasonId }    : null;
        payload.Name        = request.Name        != null ? new String { Value = request.Name }        : null;
        payload.Description = request.Description != null ? new String { Value = request.Description } : null;
        payload.VideoUrl    = request.VideoUrl    != null ? new String { Value = request.VideoUrl }    : null;
        payload.Status      = request.Status      != null ? new Int32  { Value = (int)request.Status } : null;
        payload.Price       = new Int32 { Value = request.Price };
        payload.Duration    = new Int32 { Value = request.Duration };
        
        
        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { VideoId = result.Body.VideoId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();
        
        payload.Id          = request.Id          != null ? new String { Value = request.Id }          : null;
        payload.SeasonId    = request.SeasonId    != null ? new String { Value = request.SeasonId }    : null;
        payload.Name        = request.Name        != null ? new String { Value = request.Name }        : null;
        payload.Description = request.Description != null ? new String { Value = request.Description } : null;
        payload.VideoUrl    = request.VideoUrl    != null ? new String { Value = request.VideoUrl }    : null;
        payload.Status      = request.Status      != null ? new Int32  { Value = (int)request.Status } : null;
        payload.Price       = new Int32 { Value = request.Price };
        payload.Duration    = new Int32 { Value = request.Duration };
        
        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { VideoId = result.Body.Id }
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        DeleteRequest payload = new();
        
        payload.Id = request.Id != null ? new String { Value = request.Id } : null;
        
        var result =
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { VideoId = result.Body.Id }
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        ActiveRequest payload = new();

        payload.Id = request.Id is not null ? new String { Value = request.Id } : null;

        var result = 
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { VideoId = result.Body.Id } 
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        InActiveRequest payload = new();

        payload.Id = request.Id is not null ? new String { Value = request.Id } : null;

        var result = 
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { VideoId = result.Body.Id } 
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, VideoService.VideoServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask =
            serviceDiscovery.LoadAddressInMemoryAsync(Service.TermService, cancellationToken);
        
        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());
        
        var metaData = new Metadata {
            { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new VideoService.VideoServiceClient(_channel) );
    }
}