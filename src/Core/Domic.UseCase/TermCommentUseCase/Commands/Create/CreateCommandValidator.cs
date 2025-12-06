using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermCommentUseCase.Commands.Create;

public class CreateCommandValidator : IValidator<CreateCommand>
{
    private readonly ITermRpcWebRequest _termRpcWebRequest;

    public CreateCommandValidator(ITermRpcWebRequest termRpcWebRequest) => _termRpcWebRequest = termRpcWebRequest;

    public async Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        var result = await _termRpcWebRequest.CheckExistAsync(input.TermId, cancellationToken);

        if (!result)
            throw new UseCaseException(
                string.Format("دوره ای با شناسه {0} وجود خارجی ندارد !", input.TermId ?? "_خالی_")
            );

        return default;
    }
}