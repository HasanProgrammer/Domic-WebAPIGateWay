using Domic.UseCase.RoleUseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;

namespace Domic.UseCase.ArticleCommentUseCase.Commands.Create;

public class CreateCommandValidator : IValidator<CreateCommand>
{
    private readonly IArticleRpcWebRequest _articleRpcWebRequest;

    public CreateCommandValidator(IArticleRpcWebRequest articleRpcWebRequest) 
        => _articleRpcWebRequest = articleRpcWebRequest;

    public async Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        var result = await _articleRpcWebRequest.CheckExistAsync(input.ArticleId, cancellationToken);

        if (!result)
            throw new UseCaseException(
                string.Format("مقاله ای با شناسه {0} وجود خارجی ندارد !", input.ArticleId ?? "_خالی_")
            );

        return default;
    }
}