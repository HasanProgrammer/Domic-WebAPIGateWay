using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;

namespace Domic.UseCase.RoleUseCase.Queries.ReadAllPaginated;

public class ReadAllPaginatedQueryValidator : IValidator<ReadAllPaginatedQuery>
{
    public Task<object> ValidateAsync(ReadAllPaginatedQuery input, CancellationToken cancellationToken)
    {
        if (input.CountPerPage >= 50)
            throw new UseCaseException("تعداد آیتم درخواستی شما برای گزارش گیری ، بیش از حد مجاز می باشد !");
        
        return Task.FromResult<object>(default);
    }
}