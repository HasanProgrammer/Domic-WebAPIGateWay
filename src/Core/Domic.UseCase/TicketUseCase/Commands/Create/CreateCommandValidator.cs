using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Create;

public class CreateCommandValidator(ICategoryRpcWebRequest categoryRpcWebRequest) : IValidator<CreateCommand>
{
    public async Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        var targetCategory = await categoryRpcWebRequest.CheckExistAsync(input.CategoryId, cancellationToken);
        
        if(!targetCategory)
            throw new UseCaseException("دسته بندی مورد نظر موجود نمی باشد !");

        return default;
    }
}