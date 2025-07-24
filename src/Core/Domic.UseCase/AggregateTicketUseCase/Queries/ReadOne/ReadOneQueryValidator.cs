using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;
using Domic.UseCase.TicketUseCase.Contracts.Interfaces;

namespace Domic.UseCase.AggregateTicketUseCase.Queries.ReadOne;

public class ReadOneQueryValidator(ITicketRpcWebRequest ticketRpcWebRequest) : IValidator<ReadOneQuery>
{
    public async Task<object> ValidateAsync(ReadOneQuery input, CancellationToken cancellationToken)
    {
        if(!await ticketRpcWebRequest.CheckExistAsync(input.TicketId, cancellationToken))
            throw new UseCaseException(string.Format("تیکتی با شناسه {0} موجود نمی باشد!", input.TicketId));

        return default;
    }
}