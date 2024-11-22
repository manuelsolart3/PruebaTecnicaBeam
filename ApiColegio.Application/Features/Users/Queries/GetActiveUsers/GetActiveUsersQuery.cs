using ApiColegio.Application.Abstractions.Messaging;
using ApiColegio.Domain.Abstractions;

namespace ApiColegio.Application.Features.Users.Queries.GetActiveUsers;

public record GetActiveUsersQuery(int PageNumber, int PageSize) : IQuery<Pageable>;


