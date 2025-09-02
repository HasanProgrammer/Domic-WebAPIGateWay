using Domic.Core.Domain.Exceptions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;

namespace Domic.UseCase.SeasonUseCase.Commands.Create;

public class CreateCommandValidator(ITermRpcWebRequest termRpcWebRequest) : IValidator<CreateCommand>
{
    public async Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        var targetCategory = await termRpcWebRequest.CheckExistAsync(input.TermId, cancellationToken);
        
        if (targetCategory is false)
            throw new DomainException(
                string.Format("دوره ای با شناسه {0} وجود خارجی ندارد !", input.TermId)
            );

        return default;
    }
}