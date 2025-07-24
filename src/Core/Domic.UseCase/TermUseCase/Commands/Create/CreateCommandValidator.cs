using Domic.Core.Domain.Exceptions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Commands.Create;

public class CreateCommandValidator(ICategoryRpcWebRequest categoryRpcWebRequest) : IValidator<CreateCommand>
{
    public async Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        var targetCategory = await categoryRpcWebRequest.CheckExistAsync(input.CategoryId, cancellationToken);
        
        if (targetCategory is false)
            throw new DomainException(
                string.Format("دسته بندی با شناسه {0} وجود خارجی ندارد !", input.CategoryId)
            );

        return default;
    }
}