using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;

namespace Domic.UseCase.FinancialUseCase.Queries.ReadAllTransactionPaginated;

public class ReadAllTransactionRequestPaginatedQueryValidator : IValidator<ReadAllTransactionPaginatedQuery>
{
    public Task<object> ValidateAsync(ReadAllTransactionPaginatedQuery input, CancellationToken cancellationToken)
    {
        if (input.CountPerPage >= 50)
            throw new UseCaseException("تعداد آیتم درخواستی شما برای گزارش گیری ، بیش از حد مجاز می باشد !");
        
        return Task.FromResult<object>(default);
    }
}