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
using Microsoft.Extensions.Configuration;

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
using InActiveRequest              = Domic.Core.Video.Grpc.InActiveRequest;
using InActiveResponse             = Domic.UseCase.VideoUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody         = Domic.UseCase.VideoUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;
using ReadAllPaginatedRequest      = Domic.Core.Video.Grpc.ReadAllPaginatedRequest;
using ReadOneRequest               = Domic.Core.Video.Grpc.ReadOneRequest;
using UpdateRequest                = Domic.Core.Video.Grpc.UpdateRequest;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class VideoRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
) : IVideoRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<bool> CheckExistAsync(string id, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        CheckExistRequest payload = new() { VideoId = !string.IsNullOrEmpty(id) ? new String { Value = id } : null };

        var result =
            await loadData.client.CheckExistAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return result.Result;
    }

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        ReadOneRequest payload = new() {
            VideoId = request.VideoId != null ? new String { Value = request.VideoId } : null
        };

        var result =
            await loadData.client.ReadOneAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody { Video = result.Body.Video.DeSerialize<VideosDto>() } 
        };
    }

    public async Task<ReadAllPaginatedResponse> ReadAllPaginatedAsync(ReadAllPaginatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        ReadAllPaginatedRequest payload = new() {
            PageNumber   = request.PageNumber   != null ? new Int32 { Value = (int)request.PageNumber }   : null ,
            CountPerPage = request.CountPerPage != null ? new Int32 { Value = (int)request.CountPerPage } : null
        };
        
        var result =
            await loadData.client.ReadAllPaginateAsync(payload, headers: loadData.headers, 
                cancellationToken: cancellationToken
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Videos = result.Body.Videos.DeSerialize<PaginatedCollection<VideosDto>>()
            }
        };
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        CreateRequest payload = new();

        payload.TermId      = request.TermId      != null ? new String { Value = request.TermId }      : null;
        payload.Name        = request.Name        != null ? new String { Value = request.Name }        : null;
        payload.Description = request.Description != null ? new String { Value = request.Description } : null;
        payload.VideoUrl    = request.VideoUrl    != null ? new String { Value = request.VideoUrl }    : null;
        payload.Status      = request.Status      != null ? new Int32  { Value = (int)request.Status } : null;
        
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
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        UpdateRequest payload = new();
        
        payload.TermId      = request.TermId      != null ? new String { Value = request.TermId }      : null;
        payload.Name        = request.Name        != null ? new String { Value = request.Name }        : null;
        payload.Description = request.Description != null ? new String { Value = request.Description } : null;
        payload.VideoUrl    = request.VideoUrl    != null ? new String { Value = request.VideoUrl }    : null;
        payload.Status      = request.Status      != null ? new Int32  { Value = (int)request.Status } : null;
        
        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { VideoId = result.Body.VideoId }
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        ActiveRequest payload = new();

        payload.VideoId = request.VideoId is not null ? new String { Value = request.VideoId } : null;

        var result = 
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { VideoId = result.Body.VideoId } 
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelForTermServiceAsync(cancellationToken);
        
        InActiveRequest payload = new();

        payload.VideoId = request.VideoId is not null ? new String { Value = request.VideoId } : null;

        var result = 
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { VideoId = result.Body.VideoId } 
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, VideoService.VideoServiceClient client)> 
        _loadGrpcChannelForTermServiceAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await serviceDiscovery.LoadAddressInMemoryAsync(Service.TermService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());
        
        return (
            new() {
                { Header.Token   , httpContextAccessor.HttpContext.GetRowToken() },
                { Header.License , configuration.GetValue<string>("SecretKey") }
            },
            new VideoService.VideoServiceClient(_channel)
        );
    }
}