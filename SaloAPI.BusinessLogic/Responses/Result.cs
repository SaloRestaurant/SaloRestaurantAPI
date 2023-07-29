﻿using System.Net;

namespace SaloAPI.BusinessLogic.Responses;

public record Result<TResponse> where TResponse : ResponseBase
{
    public TResponse Response { get; init; }

    public ErrorResponse Error { get; init; }

    public HttpStatusCode StatusCode { get; init; }
}