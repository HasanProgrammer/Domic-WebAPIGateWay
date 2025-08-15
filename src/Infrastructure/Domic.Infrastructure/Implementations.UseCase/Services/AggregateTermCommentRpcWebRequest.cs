using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.AggregateComment.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.AggregateTermCommentUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermCommentUseCase.DTOs;
using Domic.UseCase.AggregateTermCommentUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateTermCommentUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;

using String                       = Domic.Core.AggregateComment.Grpc.String;
using Int32                        = Domic.Core.AggregateComment.Grpc.Int32;
using ReadAllPaginatedResponse     = Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.AggregateTermCommentUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class AggregateTermCommentRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor, 
    IExternalDistributedCache distributedCache
) : IAggregateTermCommentRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<ReadOneResponse> ReadOneAsync(ReadOneQuery request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(true, cancellationToken);
        
        ReadOneRequest payload = new() {
            Id = request.Id != null ? new String { Value = request.Id } : null
        };

        var result =
            await loadData.client.ReadOneAsync(payload, cancellationToken: cancellationToken,
                headers: loadData.headers
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadOneResponseBody {
                Comment = result.Body.Comment.DeSerialize<AggregateCommentDto>()
            }
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

        payload.Active     = request.Active;
        payload.Sort       = new Int32 { Value = request.Sort };
        payload.UserId     = !string.IsNullOrEmpty(request.UserId)     ? new String { Value = request.UserId }     : null;
        payload.SearchText = !string.IsNullOrEmpty(request.SearchText) ? new String { Value = request.SearchText } : null;

        var result =
            await loadData.client.ReadAllPaginatedAsync(payload, cancellationToken: cancellationToken,
                headers: loadData.headers
            );
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ReadAllPaginatedResponseBody {
                Comments = result.Body.Comments.DeSerialize<PaginatedCollection<AggregateCommentDto>>()
            }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, CommentService.CommentServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask = 
            serviceDiscovery.LoadAddressInMemoryAsync("AggregateTermService", cancellationToken);
        
        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.License , await secretKeyTask }
        };

        var token = httpContextAccessor.HttpContext.GetRowToken();
        
        if(token is not null)
            metaData.Add(Header.Token, token);
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new CommentService.CommentServiceClient(_channel) );
    }
}