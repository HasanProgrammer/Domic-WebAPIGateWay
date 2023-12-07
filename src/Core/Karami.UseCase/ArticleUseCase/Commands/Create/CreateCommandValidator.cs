using Karami.Core.Common.ClassExtensions;
using Karami.Core.Domain.Exceptions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.UseCase.Exceptions;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;

namespace Karami.UseCase.ArticleUseCase.Commands.Create;

public class CreateCommandValidator : IValidator<CreateCommand>
{
    private readonly IUserRpcWebRequest     _userRpcWebRequest;
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;

    public CreateCommandValidator(ICategoryRpcWebRequest categoryRpcWebRequest, IUserRpcWebRequest userRpcWebRequest)
    {
        _userRpcWebRequest     = userRpcWebRequest;
        _categoryRpcWebRequest = categoryRpcWebRequest;
    }

    public async Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        if (input.Image is null || input.Image.Length == 0)
            throw new UseCaseException("فیلد تصویر شاخص مقاله الزامی می باشد !");
        
        if (!input.Image.IsImage())
            throw new UseCaseException("فرمت تصویر شاخص مقاله صحیح نمی باشد !");

        var taskUser     = _userRpcWebRequest.CheckExistAsync(input.UserId, cancellationToken);
        var taskCategory = _categoryRpcWebRequest.CheckExistAsync(input.CategoryId, cancellationToken);

        await Task.WhenAll(taskUser, taskCategory);
        
        if(await taskUser is false)
            throw new DomainException(
                string.Format("کاربری با شناسه {0} وجود خارجی ندارد !", input.UserId)
            );

        if (await taskCategory is false)
            throw new DomainException(
                string.Format("دسته بندی با شناسه {0} وجود خارجی ندارد !", input.CategoryId)
            );

        return default;
    }
}