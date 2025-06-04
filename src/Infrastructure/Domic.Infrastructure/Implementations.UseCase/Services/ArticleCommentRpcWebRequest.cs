using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.ArticleComment.Grpc;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.ArticleCommentUseCase.Commands.Active;
using Domic.UseCase.ArticleCommentUseCase.Commands.Create;
using Domic.UseCase.ArticleCommentUseCase.Commands.Delete;
using Domic.UseCase.ArticleCommentUseCase.Commands.InActive;
using Domic.UseCase.ArticleCommentUseCase.Commands.Update;
using Domic.UseCase.ArticleCommentUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using ActiveRequest        = Domic.Core.ArticleComment.Grpc.ActiveRequest;
using String               = Domic.Core.ArticleComment.Grpc.String;
using CreateResponse       = Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody   = Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using UpdateResponse       = Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody   = Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse       = Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody   = Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using CreateRequest        = Domic.Core.ArticleComment.Grpc.CreateRequest;
using DeleteRequest        = Domic.Core.ArticleComment.Grpc.DeleteRequest;
using InActiveResponse     = Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody = Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;
using DeleteResponse       = Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody   = Domic.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using InActiveRequest      = Domic.Core.ArticleComment.Grpc.InActiveRequest;
using UpdateRequest        = Domic.Core.ArticleComment.Grpc.UpdateRequest;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class ArticleCommentRpcWebRequest : IArticleCommentRpcWebRequest
{
    private readonly IServiceDiscovery         _serviceDiscovery;
    private readonly IExternalDistributedCache _distributedCache;
    private readonly IHttpContextAccessor      _httpContextAccessor;

    private GrpcChannel _channel;

    public ArticleCommentRpcWebRequest(IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery, IExternalDistributedCache distributedCache
    )
    {
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
        _distributedCache    = distributedCache;
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();

        payload.OwnerId   = request.OwnerId   != null ? new String { Value = request.OwnerId }   : null;
        payload.ArticleId = request.ArticleId != null ? new String { Value = request.ArticleId } : null;
        payload.Comment   = request.Comment   != null ? new String { Value = request.Comment }   : null;

        var result = 
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { ArticleCommentId = result.Body.CommentId } 
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();

        payload.TargetId = request.TargetId != null ? new String { Value = request.TargetId } : null;
        payload.Comment  = request.Comment  != null ? new String { Value = request.Comment }  : null;

        var result = 
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { ArticleCommentId = result.Body.CommentId } 
        };
    }

    public async Task<ActiveResponse> ActiveAsync(ActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        ActiveRequest payload = new();

        payload.TargetId = request.TargetId != null ? new String { Value = request.TargetId } : null;

        var result = 
            await loadData.client.ActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new ActiveResponseBody { ArticleCommentId = result.Body.CommentId } 
        };
    }

    public async Task<InActiveResponse> InActiveAsync(InActiveCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        InActiveRequest payload = new();

        payload.TargetId = request.TargetId != null ? new String { Value = request.TargetId } : null;

        var result = 
            await loadData.client.InActiveAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new InActiveResponseBody { ArticleCommentId = result.Body.CommentId } 
        };
    }

    public async Task<DeleteResponse> DeleteAsync(DeleteCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        DeleteRequest payload = new();

        payload.TargetId = request.TargetId != null ? new String { Value = request.TargetId } : null;

        var result = 
            await loadData.client.DeleteAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);

        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new DeleteResponseBody { ArticleCommentId = result.Body.CommentId } 
        };
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, ArticleCommentService.ArticleCommentServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask =
            _serviceDiscovery.LoadAddressInMemoryAsync(Service.ArticleService, cancellationToken);

        var secretKeyTask = _distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());

        var metaData = new Metadata {
            { Header.Token   , _httpContextAccessor.HttpContext.GetRowToken() } ,
            { Header.License , await secretKeyTask }
        };
        
        if(isIdempotent == false)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new ArticleCommentService.ArticleCommentServiceClient(_channel) );
    }
}