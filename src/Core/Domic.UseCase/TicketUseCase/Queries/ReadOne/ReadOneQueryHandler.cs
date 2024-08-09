using Domic.UseCase.TicketUseCase.DTOs.GRPCs.ReadOne;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(ITicketRpcWebRequest TicketRpcWebRequest) : IQueryHandler<ReadOneQuery, ReadOneResponse>
{
    public Task<ReadOneResponse> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => TicketRpcWebRequest.ReadOneAsync(query, cancellationToken);
}