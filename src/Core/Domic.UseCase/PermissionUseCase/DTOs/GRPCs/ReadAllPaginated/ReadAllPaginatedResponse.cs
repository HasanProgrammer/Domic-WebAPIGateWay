﻿using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.PermissionUseCase.DTOs.GRPCs.ReadAllPaginated;

public class ReadAllPaginatedResponse : BaseResponse
{
    public ReadAllPaginatedResponseBody Body { get; set; }
}