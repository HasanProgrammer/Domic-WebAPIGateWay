﻿using Domic.UseCase.Commons.DTOs.GRPCs;

namespace Domic.UseCase.TicketUseCase.DTOs.GRPCs.Create;

public class CreateResponse : BaseResponse
{
    public CreateResponseBody Body { get; set; }
}