using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.Skill.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.SkillUseCase.Commands.Active;
using Domic.UseCase.SkillUseCase.Commands.Update;
using Domic.UseCase.SkillUseCase.Commands.Create;
using Domic.UseCase.SkillUseCase.Commands.InActive;
using Domic.UseCase.SkillUseCase.Contracts.Interfaces;
using Domic.UseCase.SkillUseCase.DTOs;
using Domic.UseCase.SkillUseCase.Queries.ReadOne;
using Microsoft.AspNetCore.Http;

using String                           = Domic.Core.Skill.Grpc.String;
using Int32                            = Domic.Core.Skill.Grpc.Int32;
using ActiveRequest                    = Domic.Core.Skill.Grpc.ActiveRequest;
using CheckExistRequest                = Domic.Core.Skill.Grpc.CheckExistRequest;
using CreateRequest                    = Domic.Core.Skill.Grpc.CreateRequest;
using InActiveRequest                  = Domic.Core.Skill.Grpc.InActiveRequest;
using ReadAllPaginatedRequest          = Domic.Core.Skill.Grpc.ReadAllPaginatedRequest;
using ReadOneRequest                   = Domic.Core.Skill.Grpc.ReadOneRequest;
using UpdateRequest                    = Domic.Core.Skill.Grpc.UpdateRequest;
using ReadOneResponse                  = Domic.UseCase.SkillUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody              = Domic.UseCase.SkillUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using CreateResponse                   = Domic.UseCase.SkillUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody               = Domic.UseCase.SkillUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using ReadAllPaginatedResponse         = Domic.UseCase.SkillUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody     = Domic.UseCase.SkillUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using UpdateResponse                   = Domic.UseCase.SkillUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody               = Domic.UseCase.SkillUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse                   = Domic.UseCase.SkillUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody               = Domic.UseCase.SkillUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using DeleteResponse                   = Domic.UseCase.SkillUseCase.DTOs.GRPCs.Update.DeleteResponse;
using DeleteResponseBody               = Domic.UseCase.SkillUseCase.DTOs.GRPCs.Update.DeleteResponseBody;
using InActiveResponse                 = Domic.UseCase.SkillUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody             = Domic.UseCase.SkillUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class SkillRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor,
    IExternalDistributedCache distributedCache
) : ISkillRpcWebRequest
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
            Body    = new ReadOneResponseBody { Skill = result.Body.Skill.DeSerialize<SkillDto>() } 
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

        payload.Name = !string.IsNullOrEmpty(request.Name) ? new String { Value = request.Name } : null;
        
        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { Id = result.Body.SkillId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();

        payload.Id   = !string.IsNullOrEmpty(request.Id)   ? new String { Value = request.Id }   : null;
        payload.Name = !string.IsNullOrEmpty(request.Name) ? new String { Value = request.Name } : null;
        
        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { Id = result.Body.SkillId }
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
            Body    = new DeleteResponseBody { Id = result.Body.SkillId } 
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
            Body    = new ActiveResponseBody { Id = result.Body.SkillId } 
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
            Body    = new InActiveResponseBody { Id = result.Body.SkillId } 
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, SkillService.SkillServiceClient client)> 
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
        
        return ( metaData, new SkillService.SkillServiceClient(_channel) );
    }
}