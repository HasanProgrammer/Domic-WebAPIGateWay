#pragma warning disable CS4014

using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;
using Domic.UseCase.TermUseCase.Contracts.Interfaces;

namespace Domic.UseCase.CampaignUseCase.Commands.Create;

public class CreateCommandValidator(ITermRpcWebRequest termRpcWebRequest) : IValidator<CreateCommand>
{
    public async Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        if (!input.Terms.Any())
            throw new UseCaseException("هیچ دوره ای برای کمپین انتخاب نشده است!");
        
        foreach (var term in input.Terms)
            if (!await termRpcWebRequest.CheckExistAsync(term, cancellationToken))
                throw new UseCaseException(string.Format("دوره ای با شناسه {0} موجود نمی باشد!", term));

        return default;
    }
}