using Grpc.Core;
using Grpc.Net.Client;
using Karami.Core.Common.ClassConsts;
using Karami.Core.Grpc.ArticleComment;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Infrastructure.Extensions;
using Karami.UseCase.ArticleCommentUseCase.Commands.Active;
using Karami.UseCase.ArticleCommentUseCase.Commands.Create;
using Karami.UseCase.ArticleCommentUseCase.Commands.Delete;
using Karami.UseCase.ArticleCommentUseCase.Commands.InActive;
using Karami.UseCase.ArticleCommentUseCase.Commands.Update;
using Karami.UseCase.ArticleCommentUseCase.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using ActiveRequest        = Karami.Core.Grpc.ArticleComment.ActiveRequest;
using String               = Karami.Core.Grpc.ArticleComment.String;
using CreateResponse       = Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody   = Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using UpdateResponse       = Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody   = Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse       = Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody   = Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using CreateRequest        = Karami.Core.Grpc.ArticleComment.CreateRequest;
using DeleteRequest        = Karami.Core.Grpc.ArticleComment.DeleteRequest;
using InActiveResponse     = Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody = Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;
using DeleteResponse       = Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Delete.DeleteResponse;
using DeleteResponseBody   = Karami.UseCase.ArticleCommentUseCase.DTOs.GRPCs.Delete.DeleteResponseBody;
using InActiveRequest      = Karami.Core.Grpc.ArticleComment.InActiveRequest;
using UpdateRequest        = Karami.Core.Grpc.ArticleComment.UpdateRequest;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

public class ArticleCommentRpcWebRequest : IArticleCommentRpcWebRequest
{
    private readonly IServiceDiscovery    _serviceDiscovery;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration       _configuration;
    
    private GrpcChannel _channel;

    public ArticleCommentRpcWebRequest(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
        IServiceDiscovery serviceDiscovery
    )
    {
        _configuration       = configuration;
        _httpContextAccessor = httpContextAccessor;
        _serviceDiscovery    = serviceDiscovery;
    }

    public async Task<CreateResponse> CreateAsync(CreateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
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
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
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
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
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
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
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
        var loadData = await _loadGrpcChannelAsync(cancellationToken);
        
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
        _loadGrpcChannelAsync(CancellationToken cancellationToken)
    {
        var targetServiceInstance =
            await _serviceDiscovery.LoadAddressAsync(Service.ArticleService, cancellationToken);
        
        _channel = GrpcChannel.ForAddress(targetServiceInstance, new GrpcChannelOptions().GetAll());

        return (
            new() {
                { Header.Token   , _httpContextAccessor.HttpContext.GetRowToken() },
                { Header.License , _configuration.GetValue<string>("SecretKey") }
            },
            new ArticleCommentService.ArticleCommentServiceClient(_channel)
        );
    }
}