﻿using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.Common.ClassExtensions;
using Domic.Core.Domain.Exceptions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;

namespace Domic.UseCase.ArticleUseCase.Commands.Create;

public class CreateCommandValidator : IValidator<CreateCommand>
{
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;

    public CreateCommandValidator(ICategoryRpcWebRequest categoryRpcWebRequest) 
        => _categoryRpcWebRequest = categoryRpcWebRequest;

    public async Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        if (input.Image is null || input.Image.Length == 0)
            throw new UseCaseException("فیلد تصویر شاخص مقاله الزامی می باشد !");
        
        if (!input.Image.IsImage())
            throw new UseCaseException("فرمت تصویر شاخص مقاله صحیح نمی باشد !");

        var isExistsCategory = await _categoryRpcWebRequest.CheckExistAsync(input.CategoryId, cancellationToken);
        
        if (isExistsCategory is false)
            throw new DomainException(
                string.Format("دسته بندی با شناسه {0} وجود خارجی ندارد !", input.CategoryId)
            );

        return default;
    }
}