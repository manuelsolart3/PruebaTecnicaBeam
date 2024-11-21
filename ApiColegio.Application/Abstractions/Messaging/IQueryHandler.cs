﻿using ApiColegio.Domain.Abstractions;
using MediatR;

namespace ApiColegio.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
