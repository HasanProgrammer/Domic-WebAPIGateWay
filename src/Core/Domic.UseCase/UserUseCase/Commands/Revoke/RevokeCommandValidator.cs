using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;

namespace Domic.UseCase.UserUseCase.Commands.Revoke;

public class RevokeCommandValidator : IValidator<RevokeCommand>
{
    public Task<object> ValidateAsync(RevokeCommand input, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(input.Token))
            throw new UseCaseException("فیلد توکن الزامی می باشد !");

        return Task.FromResult(default(object));
    }
}