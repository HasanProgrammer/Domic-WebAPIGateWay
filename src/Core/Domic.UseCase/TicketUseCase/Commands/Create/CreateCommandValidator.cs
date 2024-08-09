﻿using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;

namespace Domic.UseCase.TicketUseCase.Commands.Create;

public class CreateCommandValidator : IValidator<CreateCommand>
{
    public Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(input.Title))
            throw new UseCaseException("فیلد فیلم آموزشی الزامی می باشد !");
        
        if (string.IsNullOrEmpty(input.Description))
            throw new UseCaseException("فرمت فیلم آموزشی صحیح نمی باشد !");

        return Task.FromResult(default(object));
    }
}