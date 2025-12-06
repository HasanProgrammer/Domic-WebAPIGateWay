using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;

namespace Domic.UseCase.PermissionUseCase.Queries.ReadAllBasedOnRolesPaginated;

public class ReadAllBasedOnRolesPaginatedQueryValidator : IValidator<ReadAllBasedOnRolesPaginatedQuery>
{
    public Task<object> ValidateAsync(ReadAllBasedOnRolesPaginatedQuery input, CancellationToken cancellationToken)
    {
        if (input.CountPerPage >= 50)
            throw new UseCaseException("تعداد آیتم درخواستی شما برای گزارش گیری ، بیش از حد مجاز می باشد !");
        
        return Task.FromResult<object>(default);
    }
}