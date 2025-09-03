using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;

namespace Domic.UseCase.SeasonUseCase.Queries.ReadAllBasedOnTermId;

public class ReadAllBasedOneTermIdValidateQueryHandler(ITermRpcWebRequest termRpcWebRequest) 
    : IValidator<ReadAllBasedOnTermIdQuery>
{
    public async Task<object> ValidateAsync(ReadAllBasedOnTermIdQuery query, CancellationToken cancellationToken)
    {
        if (!await termRpcWebRequest.CheckExistAsync(query.TermId, cancellationToken))
            throw new UseCaseException(string.Format("دوره ای با شناسه {0} موجود نمی باشد", query.TermId));

        return default;
    }
}