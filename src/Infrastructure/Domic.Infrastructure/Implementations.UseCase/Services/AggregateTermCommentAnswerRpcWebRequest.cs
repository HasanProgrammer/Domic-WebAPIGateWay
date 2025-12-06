using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.AggregateCommentAnswer.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.Contracts.Interfaces;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.AggregateTermCommentAnswerUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;

using String                       = Domic.Core.AggregateCommentAnswer.Grpc.String;
using Int32                        = Domic.Core.AggregateCommentAnswer.Grpc.Int32;
using ReadAllPaginatedResponse     = Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody = Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using ReadOneResponse              = Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody          = Domic.UseCase.AggregateTermCommentAnswerUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class AggregateTermCommentAnswerRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor, 
    IExternalDistributedCache distributedCache
) : IAggregateTermCommentAnswerRpcWebRequest
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
                Answer = result.Body.Answer.DeSerialize<AggregateCommentAnswerDto>()
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
        payload.CommentId  = new String { Value = request.CommentId };
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
                Answers = result.Body.Answers.DeSerialize<PaginatedCollection<AggregateCommentAnswerDto>>()
            }
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, CommentAnswerService.CommentAnswerServiceClient client)> 
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
        
        return ( metaData, new CommentAnswerService.CommentAnswerServiceClient(_channel) );
    }
}