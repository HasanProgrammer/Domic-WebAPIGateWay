﻿using Domic.UseCase.VideoUseCase.DTOs;

namespace Domic.UseCase.VideoUseCase.DTOs.GRPCs.ReadOne;

public class ReadOneResponseBody
{
    public VideosDto Video { get; set; }
}