using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.UseCase.Exceptions;

namespace Karami.UseCase.ArticleUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryValidator : IValidator<ReadAllPaginatedQuery>
{
    public Task<object> ValidateAsync(ReadAllPaginatedQuery input, CancellationToken cancellationToken)
    {
        if (input.CountPerPage >= 50)
            throw new UseCaseException("تعداد آیتم درخواستی شما برای گزارش گیری ، بیش از حد مجاز می باشد !");
        
        return Task.FromResult<object>(default);
    }
}