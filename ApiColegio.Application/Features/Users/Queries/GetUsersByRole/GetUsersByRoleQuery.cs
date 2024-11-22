using ApiColegio.Application.Abstractions.Messaging;
using ApiColegio.Domain.Abstractions;

namespace ApiColegio.Application.Features.Users.Queries.GetUsersByRole;

public record GetUsersByRoleQuery(string Role, int PageNumber, int PageSize) : IQuery<Pageable>;

