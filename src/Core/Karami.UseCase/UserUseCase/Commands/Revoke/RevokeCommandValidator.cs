using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.UseCase.Exceptions;

namespace Karami.UseCase.UserUseCase.Commands.Revoke;

public class RevokeCommandValidator : IValidator<RevokeCommand>
{
    public async Task<object> ValidateAsync(RevokeCommand input, CancellationToken cancellationToken)
    {
        await Task.Run(() => {
            
            if (string.IsNullOrEmpty(input.Token))
                throw new UseCaseException("فیلد توکن الزامی می باشد !");
            
        });

        return default;
    }
}