using ApiColegio.Application.Abstractions.Messaging;
using ApiColegio.Domain.Abstractions;

namespace ApiColegio.Application.Features.Users.Queries.GetUserByName;

public record GetUsersByNameQuery(string Name, int PageNumber, int PageSize) : IQuery<Pageable>;
