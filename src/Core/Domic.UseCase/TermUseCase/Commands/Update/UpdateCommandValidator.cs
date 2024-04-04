using Domic.Core.Common.ClassExtensions;
using Domic.Core.Domain.Exceptions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;
using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Commands.Update;

public class UpdateCommandValidator(ICategoryRpcWebRequest categoryRpcWebRequest, ITermRpcWebRequest termRpcWebRequest) 
    : IValidator<UpdateCommand>
{
    public async Task<object> ValidateAsync(UpdateCommand input, CancellationToken cancellationToken)
    {
        if (input.Image is null || input.Image.Length == 0)
            throw new UseCaseException("فیلد تصویر شاخص دوره الزامی می باشد !");
        
        if (!input.Image.IsImage())
            throw new UseCaseException("فرمت تصویر شاخص دوره صحیح نمی باشد !");
        
        var targetTermTask = termRpcWebRequest.CheckExistAsync(input.TermId, cancellationToken);
        var targetCategoryTask = categoryRpcWebRequest.CheckExistAsync(input.CategoryId, cancellationToken);

        await Task.WhenAll(targetTermTask, targetCategoryTask);
        
        if (await targetTermTask is false)
            throw new DomainException(
                string.Format("دوره ای با شناسه {0} وجود خارجی ندارد !", input.CategoryId)
            );
        
        if (await targetCategoryTask is false)
            throw new DomainException(
                string.Format("دسته بندی با شناسه {0} وجود خارجی ندارد !", input.CategoryId)
            );

        return default;
    }
}