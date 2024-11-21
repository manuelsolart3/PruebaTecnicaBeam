using ApiColegio.Domain.Abstractions;
using MediatR;

namespace ApiColegio.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}