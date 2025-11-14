using Grpc.Core;
using Grpc.Net.Client;
using Domic.Core.Common.ClassConsts;
using Domic.Core.Common.ClassHelpers;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.Company.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Infrastructure.Extensions;
using Domic.UseCase.CompanyUseCase.Contracts.Interfaces;
using Domic.UseCase.CompanyUseCase.Commands.Active;
using Domic.UseCase.CompanyUseCase.Commands.Update;
using Domic.UseCase.CompanyUseCase.Commands.Create;
using Domic.UseCase.CompanyUseCase.Commands.InActive;
using Domic.UseCase.CompanyUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.CompanyUseCase.Queries.ReadOne;
using Domic.UseCase.CompanyUseCase.Contracts.Interfaces;
using Domic.UseCase.CompanyUseCase.DTOs;
using Microsoft.AspNetCore.Http;

using String                           = Domic.Core.Company.Grpc.String;
using Int32                            = Domic.Core.Company.Grpc.Int32;
using ActiveRequest                    = Domic.Core.Company.Grpc.ActiveRequest;
using CheckExistRequest                = Domic.Core.Company.Grpc.CheckExistRequest;
using CreateRequest                    = Domic.Core.Company.Grpc.CreateRequest;
using InActiveRequest                  = Domic.Core.Company.Grpc.InActiveRequest;
using ReadAllPaginatedRequest          = Domic.Core.Company.Grpc.ReadAllPaginatedRequest;
using ReadOneRequest                   = Domic.Core.Company.Grpc.ReadOneRequest;
using UpdateRequest                    = Domic.Core.Company.Grpc.UpdateRequest;
using ReadOneResponse                  = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using ReadOneResponseBody              = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadOne.ReadOneResponseBody;
using CreateResponse                   = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Create.CreateResponse;
using CreateResponseBody               = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Create.CreateResponseBody;
using ReadAllPaginatedResponse         = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponse;
using ReadAllPaginatedResponseBody     = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.ReadAllPaginated.ReadAllPaginatedResponseBody;
using UpdateResponse                   = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Update.UpdateResponse;
using UpdateResponseBody               = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Update.UpdateResponseBody;
using ActiveResponse                   = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Active.ActiveResponse;
using ActiveResponseBody               = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Active.ActiveResponseBody;
using DeleteResponse                   = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Update.DeleteResponse;
using DeleteResponseBody               = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.Update.DeleteResponseBody;
using InActiveResponse                 = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.InActive.InActiveResponse;
using InActiveResponseBody             = Domic.UseCase.CompanyUseCase.DTOs.GRPCs.InActive.InActiveResponseBody;

namespace Domic.Infrastructure.Implementations.UseCase.Services;

public class CompanyRpcWebRequest(
    IServiceDiscovery serviceDiscovery, IHttpContextAccessor httpContextAccessor,
    IExternalDistributedCache distributedCache
) : ICompanyRpcWebRequest
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
            Body    = new ReadOneResponseBody { Company = result.Body.Company.DeSerialize<CompanyDto>() } 
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
        payload.Description = !string.IsNullOrEmpty(request.Description) ? new String { Value = request.Description } : null;
        payload.Field = !string.IsNullOrEmpty(request.Field) ? new String { Value = request.Field } : null;
        payload.Size = request.Size != null ? new Int32 { Value = request.Size.Value } : null;
        payload.WebsiteUrl = !string.IsNullOrEmpty(request.WebsiteUrl) ? new String { Value = request.WebsiteUrl } : null;
        payload.ImagePath = !string.IsNullOrEmpty(request.ImagePath) ? new String { Value = request.ImagePath } : null;
        
        var result =
            await loadData.client.CreateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new CreateResponseBody { Id = result.Body.CompanyId }
        };
    }

    public async Task<UpdateResponse> UpdateAsync(UpdateCommand request, CancellationToken cancellationToken)
    {
        var loadData = await _loadGrpcChannelAsync(false, cancellationToken);
        
        UpdateRequest payload = new();

        payload.Id = !string.IsNullOrEmpty(request.Id) ? new String { Value = request.Id } : null;
        payload.Name = !string.IsNullOrEmpty(request.Name) ? new String { Value = request.Name } : null;
        payload.Description = !string.IsNullOrEmpty(request.Description) ? new String { Value = request.Description } : null;
        payload.Field = !string.IsNullOrEmpty(request.Field) ? new String { Value = request.Field } : null;
        payload.Size = request.Size != null ? new Int32 { Value = request.Size.Value } : null;
        payload.WebsiteUrl = !string.IsNullOrEmpty(request.WebsiteUrl) ? new String { Value = request.WebsiteUrl } : null;
        payload.ImagePath = !string.IsNullOrEmpty(request.ImagePath) ? new String { Value = request.ImagePath } : null;
        
        var result =
            await loadData.client.UpdateAsync(payload, headers: loadData.headers, cancellationToken: cancellationToken);
        
        return new() {
            Code    = result.Code    ,
            Message = result.Message ,
            Body    = new UpdateResponseBody { Id = result.Body.CompanyId }
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
            Body    = new DeleteResponseBody { Id = result.Body.CompanyId } 
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
            Body    = new ActiveResponseBody { Id = result.Body.CompanyId } 
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
            Body    = new InActiveResponseBody { Id = result.Body.CompanyId } 
        };
    }

    public void Dispose() => _channel.Dispose();
    
    /*---------------------------------------------------------------*/

    private async Task<(Metadata headers, CompanyService.CompanyServiceClient client)> 
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
        
        return ( metaData, new CompanyService.CompanyServiceClient(_channel) );
    }
}