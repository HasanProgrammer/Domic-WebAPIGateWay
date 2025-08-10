﻿using Domic.Core.Common.ClassHelpers;
using Domic.UseCase.Commons.DTOs;

namespace Domic.UseCase.TermCommentAnswerUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponseBody
{
    public PaginatedCollection<AnswerDto> Answers { get; set; }
}