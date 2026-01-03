using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Notification.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.NotificationUseCase.Contracts.Interfaces;
using Domic.UseCase.NotificationUseCase.Commands.VerifyCode;

using String             = Domic.Core.Notification.Grpc.String;
using CreateResponse     = Domic.UseCase.NotificationUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody = Domic.UseCase.NotificationUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using CreateRequest      = Domic.Core.Notification.Grpc.CreateRequest;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class NotificationRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IExternalDistributedCache distributedCache
) : INotificationRpcWebRequest
{
    private GrpcChannel _channel;

    public async Task<CreateResponse> SendEmailVerifyCodeAsync(VerifyCodeCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        CreateRequest payload = new();

        payload.EmailAddress = !string.IsNullOrWhiteSpace(request.EmailAddress)
            ? new String { Value = request.EmailAddress }
            : default;
        
        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { Result = result.Body.Result }
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, NotificationService.NotificationServiceClient client)> 
        _loadGrpcChannelAsync(bool isIdempotent, CancellationToken cancellationToken)
    {
        var targetServiceInstanceTask =
            serviceDiscovery.LoadAddressInMemoryAsync("NotificationService", cancellationToken);
        
        var secretKeyTask = distributedCache.GetCacheValueAsync("SecretKey", cancellationToken);

        await Task.WhenAll(targetServiceInstanceTask, secretKeyTask);
        
        _channel = GrpcChannel.ForAddress(await targetServiceInstanceTask, new GrpcChannelOptions().GetAll());
        
        var metaData = new Metadata {
            { Header.License , await secretKeyTask }
        };
        
        if(!isIdempotent)
            metaData.Add(Header.IdempotentKey, Guid.NewGuid().ToString());
        
        return ( metaData, new NotificationService.NotificationServiceClient(_channel) );
    }
}